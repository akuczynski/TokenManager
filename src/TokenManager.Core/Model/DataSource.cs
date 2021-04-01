using System.Collections.Generic;

namespace TokenManager.Core.Model
{
    public class DataSource
    {
        private Dictionary<Environment, IList<Token>> EnvironmentTokens { get; set; }

        public DataSource()
        {
            EnvironmentTokens = new Dictionary<Environment, IList<Token>>();
        }

        public void Add(Environment environment, IList<Token> tokens)
        {
            EnvironmentTokens.Add(environment, tokens);
        }
    }
}
