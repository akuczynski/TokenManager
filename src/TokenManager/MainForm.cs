﻿using System.ComponentModel.Composition;
using System.Windows.Forms;
using TokenManager.Core.DomainServices;
using TokenManager.Core.Events;
using TokenManager.Forms;
using TokenManager.Properties;

namespace TokenManager
{
    public partial class MainForm : Form, IEventHandler, IMainForm
    {
        [Import]
        public INotificationService NotyficationService { get; set; }

        public MainForm()
        {
            InitializeComponent();

            Shell.CompositionContainer.ComposeParts(this);
            Shell.CompositionContainer.ComposeParts(this.MenuPanel);
            Shell.CompositionContainer.ComposeParts(this.TokensGrid);

            this.MenuPanel.MainForm = this;
            this.TokensGrid.MainForm = this;

            NotyficationService.Subscribe(typeof(ModelHasChangedEvent), this);
            NotyficationService.Subscribe(typeof(ProjectLoadedEvent), this);
            NotyficationService.Subscribe(typeof(ProjectSavedEvent), this);
            NotyficationService.Subscribe(typeof(SelectTokenEvent), this);
        }

        void IEventHandler.Handle(IEvent appEvent)
        {
            if (appEvent is ProjectLoadedEvent)
            {
                MenuPanel.Init();

                TokensGrid.ShowData(true, true, false, false, null);
                StatubBarLbl.Text = Messages.DataLoaded;
            }
            else if (appEvent is ModelHasChangedEvent)
            {
                MenuPanel.ReloadTokenGrid(); 
            }
            else if (appEvent is SelectTokenEvent)
            {
                var token = (appEvent as SelectTokenEvent).Token;
                TokensGrid.Select(token);
            }
            else if (appEvent is ProjectSavedEvent)
            {
                UpdateMessageOnStatusBar(Messages.DataSaved);
            }
        }

        public void FilterTokenGrid(bool showTokens, bool showSubTokens, bool onlyPasswords, bool onlyGlobal, string tokenName)
        {
            TokensGrid.ShowData(showTokens, showSubTokens, onlyPasswords, onlyGlobal, tokenName);
        }

        public void UpdateMessageOnStatusBar(string text)
        {
            StatubBarLbl.Text = text;
        }

        public void ShowTokenModalWindow(bool isEdit, string token)
        {
            var modalWindow = new TokenForm();
            Shell.CompositionContainer.ComposeParts(modalWindow);

            modalWindow.MainForm = this;
            modalWindow.Init(isEdit, token);
            modalWindow.ShowDialog(this);
        }

        public void ShowEnvironmentModalWindow()
        {
            var modalWindow = new EnvironmentForm();
            Shell.CompositionContainer.ComposeParts(modalWindow);
            

            modalWindow.ShowDialog(this);
        }
    }
} 