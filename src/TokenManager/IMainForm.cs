namespace TokenManager
{
    public interface IMainForm
    {
        void FilterTokenGrid(bool showTokens, bool showSubTokens, string tokenName);

        void UpdateMessageOnStatusBar(string text);
    }
}
