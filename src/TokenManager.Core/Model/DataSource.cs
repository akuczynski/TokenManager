using System.Collections.Generic;
using System.Linq;

namespace TokenManager.Core.Model
{
    public delegate void ModelChangedHandler(Token token, Action action, bool isGlobal);

    public class DataSource
    {
        private Dictionary<Environment, IList<Token>> EnvironmentTokens { get; set; }

        public IEnumerable<Environment> GetAllEnvironments()
        {
            return EnvironmentTokens.Keys;
        }

        public Environment GetEnvironment(string name)
        {
            return EnvironmentTokens.Keys.SingleOrDefault(x => x.Name.Equals(name));
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

        public IEnumerable<Token> GetAllTokens(Environment environment)
        {
            var globalTokens = GetTokens(RootEnvironment);
            var environementTokens = GetTokens(environment);

            var result = new List<Token>(globalTokens);

            foreach(var token in environementTokens)
            {
                var overridenToken = globalTokens.Where(x => x.Key.Equals(token.Key)).SingleOrDefault();
                if (overridenToken != null)
                {
                    result.Remove(overridenToken);
                }
            }

            result.AddRange(environementTokens);

            return result;
        }

        public void Clean(Environment environment)
        {
            var deletedTokens = GetTokens(environment).Where(x => x.IsDirty && x.Action == Action.Delete).ToList();

            foreach (var token in deletedTokens)
            {
                EnvironmentTokens[environment].Remove(token);
            }

            IsDirty = false;
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
            bool isGlobal = false;

            foreach (var env in GetAllEnvironments())
            {
                var token = FindToken(tokenName, env);
                if (token != null)
                {
                    if (env == RootEnvironment)
                    {
                        isGlobal = true;
                    }

                    token.Action = Action.Delete;
                    token.IsDirty = true;

                    modelHasChanged = true;
                }
            }

            if (modelHasChanged)
            {
                var token = new Token { Key = tokenName };
                Notify(token, Action.Delete, isGlobal);
            }
        }

        public void UpdateToken(Token token)
        {
            token.IsDirty = true;
            token.Action = Action.Update;

            Notify(token, Action.Update, true);
        }

        public void UpdateTokenAssigment(Token token)
        {
            token.IsDirty = true;
            token.Action = Action.Update;

            Notify(token, Action.TokenValueAssigment, true);
        }

        public void AddToken(Token token, Environment environment)
        {
            token.IsDirty = true;
            token.Action = Action.Insert;

            EnvironmentTokens[environment].Add(token);
            var isGlobal = environment == RootEnvironment;
            Notify(token, Action.Insert, isGlobal);
        }

        public void AddTokenAssigment(Token token, Environment environment)
        {
            token.IsDirty = true;
            token.Action = Action.Insert;

            EnvironmentTokens[environment].Add(token);
            Notify(token, Action.TokenValueAssigment, false);
        }

        private void Notify(Token token, Action action, bool isGlobal)
        {
            IsDirty = true;
            this.ModelChanged(token, action, isGlobal);
        }

        private Token FindToken(string tokenName, Environment environment)
        {
            return EnvironmentTokens[environment].FirstOrDefault(x => x.Key.Equals(tokenName));
        }
    }
}
