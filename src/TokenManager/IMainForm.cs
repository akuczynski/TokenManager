namespace TokenManager
{
    public interface IMainForm
    {
        void FilterTokenGrid(bool showTokens, bool showSubtokens, bool onlyPasswords, bool onlyGlobal, string tokenName);

        void UpdateMessageOnStatusBar(string text);

        void ShowTokenModalWindow(bool isEdit, string title, bool isSubtoken = false, string token = null);

        void ShowEnvironmentModalWindow(string token, string environment);
    }
}
