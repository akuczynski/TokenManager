namespace TokenManager
{
    public interface IMainForm
    {
        void FilterTokenGrid(bool showTokens, bool showSubTokens, bool onlyPasswords, bool onlyGlobal, string tokenName);

        void UpdateMessageOnStatusBar(string text);

        void ShowTokenModalWindow(bool isEdit, bool isSubtoken = false, string token = null);

        void ShowEnvironmentModalWindow(string token, string environment);
    }
}
