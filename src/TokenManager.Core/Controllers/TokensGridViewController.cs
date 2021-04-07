﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using TokenManager.Core.Events;
using TokenManager.Core.ViewModel;

namespace TokenManager.Core.DomainServices
{
    public interface ITokensGridViewController
    {
        IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, bool onlyPasswords, bool onlyGlobal, string tokenName);

        IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName);
        void RemoveToken(string tokenName);
    }

    [Export(typeof(ITokensGridViewController))]
    internal class TokensGridViewController : ITokensGridViewController, IEventHandler
    {
        private readonly INotificationService _notificationService;

        private readonly ITokenManagementService _tokenManagementService;

        [ImportingConstructor]
        public TokensGridViewController(
            ITokenManagementService tokenManagementService,
            INotificationService notificationService)
        {
            _notificationService = notificationService;
            _tokenManagementService = tokenManagementService;

            _notificationService.Subscribe(typeof(ProjectLoadedEvent), this);
        }

        public IEnumerable<TokenViewModel> GetTokenList(bool showTokens, bool showSubTokens, bool onlyPasswords, bool onlyGlobal, string tokenName)
        {
            var result = Enumerable.Empty<TokenViewModel>();

            if (showSubTokens && showTokens)
            {
                result = _tokenManagementService.Tokens.ToList();
            }
            else if (showTokens == false && showSubTokens == true)
            {
                result = _tokenManagementService.Tokens.Where(x => x.IsSubToken == true).ToList();
            }
            else if (showTokens == true && showSubTokens == false)
            {
                result = _tokenManagementService.Tokens.Where(x => x.IsSubToken == false).ToList();
            }

            if (!string.IsNullOrEmpty(tokenName))
            {
                result = result.Where(x => x.Token.ToLower().Contains(tokenName.ToLower())).ToList();
            }

            if (onlyPasswords)
            {
                result = result.Where(x => x.Password == true).ToList();
            }

            if (onlyGlobal)
            {
                result = result.Where(x => x.Global).ToList();
            }



            return result.OrderBy(token => token.IsSubToken).ToList(); 
        }

        public IEnumerable<EnvironentTokenViewModel> GetTokenValuesForAllEnvironments(string tokenName)
        {
            return _tokenManagementService.GetTokenValuesForAllEnvironments(tokenName);
        } 

        public void Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                _tokenManagementService.Init();
            }
        }

        public void RemoveToken(string tokenName)
        {
            _tokenManagementService.RemoveToken(tokenName);
        }
    }
}
