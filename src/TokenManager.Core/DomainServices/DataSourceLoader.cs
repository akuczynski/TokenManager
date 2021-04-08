using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using TokenManager.Core.Model;
using Xml = TokenManager.Core.DomainServices.XmlConstants;

namespace TokenManager.Core.DomainServices
{
    public interface IDataSourceLoader
    {
        IList<Token> ReadTokens(string filePath);
    }

    [Export(typeof(IDataSourceLoader))]
    internal class DataSourceLoader : IDataSourceLoader
    {
        public IList<Token> ReadTokens(string filePath)
        {
            XDocument tokensXml = XDocument.Load(filePath);
            var result = new List<Token>();
        
            foreach (var childNode in tokensXml.Root.Elements())
            {
                if (childNode.Name.LocalName.Equals(Xml.SubTokensNodeName))
                {
                    var subTokens = ReadSubTokens(childNode);
                    result.AddRange(subTokens);

                    continue;
                }
                else
                {
                    var token = new Token();

                    token.Key = ReadAttribute(childNode, Xml.KeyAttributeName);
                    token.Value = ReadAttribute(childNode, Xml.ValueAttributeName);
                    token.IsPassword = ReadAttribute(childNode, Xml.PasswordAttributeName) == "true";
                    token.Description = ReadAttribute(childNode, Xml.DescriptionAttributeName);
                    token.UserName = ReadAttribute(childNode, Xml.UserNameAttributeName);
                    token.Xml = childNode;

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

                token.Key = ReadAttribute(childNode, Xml.KeyAttributeName);
                token.Value = ReadAttribute(childNode, Xml.ValueAttributeName);
                token.IsPassword = ReadAttribute(childNode, Xml.PasswordAttributeName) == "true";
                token.Description = ReadAttribute(childNode, Xml.DescriptionAttributeName);
                token.UserName = ReadAttribute(childNode, Xml.UserNameAttributeName);
                token.Xml = childNode;

                result.Add(token);
            }

            return result;
        }

        private string ReadAttribute(XElement xElement, string attributeName)
        {
            return xElement.Attributes().Where(x => x.Name.LocalName.Equals(attributeName, System.StringComparison.OrdinalIgnoreCase)).SingleOrDefault()?.Value;
        }
    }
}
