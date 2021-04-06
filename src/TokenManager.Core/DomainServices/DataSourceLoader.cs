using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Xml;
using System.Xml.Linq;
using TokenManager.Core.Model;

namespace TokenManager.Core.DomainServices
{
    public interface IDataSourceLoader
    {
        IList<Token> ReadTokens(string filePath);
    }

    [Export(typeof(IDataSourceLoader))]
    internal class DataSourceLoader : IDataSourceLoader
    {
        private const string SubTokensNodeName = "subtokens";

        public IList<Token> ReadTokens(string filePath)
        {
            XDocument tokensXml = XDocument.Load(filePath);
            var result = new List<Token>();
        
            foreach (var childNode in tokensXml.Root.Elements())
            {
                if (childNode.Name.LocalName.Equals(SubTokensNodeName))
                {
                    var subTokens = ReadSubTokens(childNode);
                    result.AddRange(subTokens);

                    continue;
                }
                else
                {
                    var token = new Token();
                    token.Key = childNode.Attribute("key").Value;
                    token.Value = childNode.Attribute("value").Value;

                    // todo
                    result.Add(token);
                }
            }

            return result;
        }

        private IList<Token> ReadSubTokens(XElement subTokensNode)
        {
            var result = new List<Token>();

            foreach (var childNode in subTokensNode.Elements())
            {
                var token = new Token { IsSubToken = true };
                token.Key = childNode.Attribute("key").Value;
             //   token.Value = childNode.Attribute("value").Value;

                // todo
                result.Add(token);
            }

            return result;
        }
    }
}
