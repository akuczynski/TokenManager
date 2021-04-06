using System.Windows.Forms;

namespace TokenManager
{
    public interface IMainForm
    {
        void FilterTokenGrid(bool showTokens, bool showSubTokens, bool onlyPasswords, string tokenName);

        void UpdateMessageOnStatusBar(string text);

        void ShowTokenModalWindow(bool isEdit, string token = null);
    }
}
