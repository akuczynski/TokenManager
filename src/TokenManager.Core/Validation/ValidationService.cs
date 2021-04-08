using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text.RegularExpressions;
using TokenManager.Core.Model;

namespace TokenManager.Core.Validation
{
    public interface IValidationService
    {
        ValidationResult Validate(DataSource dataSource);
    }

    [Export(typeof(IValidationService))]
    internal class ValidationService : IValidationService
    {
        private List<string> _globalTokens;

        private List<string> _environmentsTokens;

        public ValidationService()
        {
            _globalTokens = new List<string>();
            _environmentsTokens = new List<string>();
        }

        public ValidationResult Validate(DataSource dataSource)
        {
            var root = dataSource.RootEnvironment;
            _globalTokens = dataSource.GetTokens(root)
                .Where(x => x.Action != Model.Action.Delete)
                .Select(y => y.Key)
                .ToList();

            foreach (var environment in dataSource.GetAllEnvironments())
            {
                if (environment.Equals(root))
                {
                    continue;
                }

                var environmentTokens = dataSource.GetTokens(environment)
                    .Where(x => x.Action != Model.Action.Delete)
                    .Select(y => y)
                    .ToList();

                _environmentsTokens = environmentTokens.Select(x => x.Key).ToList();
                try
                {
                    foreach (var token in environmentTokens)
                    {
                        CheckTokenValue(token);
                    }
                }
                catch (Exception ex)
                {
                    return new ValidationResult
                    {
                        IsValid = false,
                        Message = string.Format("Environment: [{0}] \n{1}", environment.Name, ex.Message)
                    };
                }
            }

            return new ValidationResult { IsValid = true };
        }


        private void CheckTokenValue(Token token)
        {
            if (string.IsNullOrEmpty(token.Value))
            {
                return;
            }

            if (token.Value.Contains("##"))
            {
                var tokenReferences = GetTokenReferences(token.Value);

                foreach (var tokenReference in tokenReferences)
                {
                    var exists = CheckIfTokenExists(tokenReference);
                    if (!exists)
                    {
                        var message = string.Format("{0} has invalid reference to {1}.", token.Key, tokenReference);
                        throw new Exception(message);
                    }
                }
            }
        }

        private IEnumerable<string> GetTokenReferences(string tokenValue)
        {
            var pattern = @"##([^##]* *)*##";
            var regex = new Regex(pattern);
            var result = new List<string>();

            var matches = regex.Matches(tokenValue);
            foreach (Match match in matches)
            {
                var tokenName = match.Groups[0].Value;
                result.Add(tokenName);
            }

            return result;
        }

        private bool CheckIfTokenExists(string token)
        {
            if (!_globalTokens.Contains(token))
            {
                if (!_environmentsTokens.Contains(token))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
