using System.Collections.Generic;
using System.Linq;

namespace TokenManager.Core.Model
{
    public delegate void ModelChangedHandler(string token, Action action);

    public class DataSource
    {
        private Dictionary<Environment, IList<Token>> EnvironmentTokens { get; set; }

        public IEnumerable<Environment> GetAllEnvironments()
        {
            return EnvironmentTokens.Keys;
        }

        public event ModelChangedHandler ModelChanged;

        public bool IsDirty { get; private set; }

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

        public Token GetToken(string tokenName, Environment environment = null)
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
            IsDirty = false;
        }

        public void Add(Environment environment, IList<Token> tokens)
        {
            EnvironmentTokens.Add(environment, tokens);
        }

        public void RemoveToken(string tokenName)
        {
            var modelHasChanged = false; 

            foreach(var env in GetAllEnvironments())
            {
                var token = FindToken(tokenName, env); 
                if (token != null)
                {
                    token.Action = Action.Delete;
                    token.IsDirty = true;
                    this.IsDirty = true;
                    
                    modelHasChanged = true;
                }
            }

            if (modelHasChanged)
            {
                Notify(tokenName, Action.Delete);
            }
        }

        public void AddToken(Token token, string environment)
        {
            token.IsDirty = true;
            token.Action = Action.Insert;

        //    EnvironmentTokens[environment].Add(token);
        }

        private void Notify(string tokenName, Action action)
        {
            this.ModelChanged(tokenName, action);
        }

        private Token FindToken(string tokenName, Environment environment)
        {
            return EnvironmentTokens[environment].FirstOrDefault(x => x.Key.Equals(tokenName));
        } 
    }
}
