using System.Collections.Generic;

namespace TokenManager.Core.Model
{
    public class DataSource
    {
        public Dictionary<Environment, IList<Token>> EnvironmentTokens { get; private set; }

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
