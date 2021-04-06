using System.Collections.Generic;
using System.Linq;

namespace TokenManager.Core.Model
{
    public class DataSource
    {
        private Dictionary<Environment, IList<Token>> EnvironmentTokens { get; set; }


        public IEnumerable<Environment> GetAllEnvironments()
        {
            return EnvironmentTokens.Keys;
        }

        public Environment RootEnvironment
        {
            get
            {
                return EnvironmentTokens.Keys.Where(x => x.IsRoot == true).SingleOrDefault(); 
            }
        }

        public IEnumerable<Token> GetTokens(Environment environment)
        {
            return EnvironmentTokens[environment];
        }

        public Token GetTokenOrDefault(string tokenName, Environment environment)
        {
            var token = GetToken(tokenName, environment);

            if (token is EmptyToken && environment != RootEnvironment)
            {
                return GetToken(tokenName, RootEnvironment);
            }

            return token;
        }

        private Token GetToken(string tokenName, Environment environment = null)
        {
            Token token = null;

            if (environment == null)
            {
                token = EnvironmentTokens[RootEnvironment].Where(x => x.Key.Equals(tokenName)).SingleOrDefault();
            }
            else
            {
                token = EnvironmentTokens[environment].Where(x => x.Key.Equals(tokenName)).SingleOrDefault();
            }
             
            if (token == null)
            {
                return new EmptyToken();
            }

            return token;
        }

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
