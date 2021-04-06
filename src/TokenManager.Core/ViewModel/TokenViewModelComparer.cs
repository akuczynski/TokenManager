using System.Collections.Generic;

namespace TokenManager.Core.ViewModel
{
    internal class TokenViewModelComparer : IEqualityComparer<TokenViewModel>
    {
        public bool Equals(TokenViewModel token1, TokenViewModel token2)
        {
            if (token1 == null && token2 == null) { return true; }
            if (token1 == null | token2 == null) { return false; }

            if (token1.Token == token2.Token) { return true; }
            return false;
        }
      

        public int GetHashCode(TokenViewModel token)
        {
            return token.Token.GetHashCode();
        }
    }
}
