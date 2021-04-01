using System.Collections.Generic;

namespace TokenManager.Core.Model
{
    public class DataSource
    {
        private IList<EnvironmentToken> EnvironmentTokens { get; set; }

        public DataSource()
        {
            // TODO: 
        }

        private class EnvironmentToken
        {
            public Environment Environment { get; set; }

            public List<Token> Tokens { get; set; }
        }
    }
}
