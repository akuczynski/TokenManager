using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TokenManager.Core.Model;

namespace TokenManager.Core.DomainServices
{
    public interface IDataSourceWritter
    {
        void WriteTokens(IEnumerable<Token> tokens, string filePath);
    }

    [Export(typeof(IDataSourceWritter))]
    internal class DataSourceWritter : IDataSourceWritter
    {
        private const string SubTokensNodeName = "subtokens";

        private const string TokensNodeName = "tokens";

        private const string TokenNodeName = "token";

        private const string KeyAttributeName = "key";

        private const string ValueAttributeName = "value";

        private const string DescriptionAttributeName = "description";

        private const string PasswordAttributeName = "password";

        private const string UserNameAttributeName = "userName";

        public void WriteTokens(IEnumerable<Token> tokens, string filePath)
        {
            if (tokens.Any())
            {
                XDocument tokensXml = XDocument.Load(filePath);

                foreach (var token in tokens)
                {
                    if (token.Action == Model.Action.Insert)
                    {
                        WriteToken(token, tokensXml);

                        token.IsDirty = false;
                        token.Action = Model.Action.None;
                    }
                    else
                    {
                        var xmlNode = FindXmlTokenNode(token, tokensXml);
                        if (xmlNode != null)
                        {
                            if (token.Action == Model.Action.Delete)
                            {
                                xmlNode.Remove();
                            }

                            else if (token.Action == Model.Action.Update)
                            {
                                WriteToken(token, tokensXml);

                                token.IsDirty = false;
                                token.Action = Model.Action.None;
                            }
                        }
                    }
                }

                tokensXml.Save(filePath);
            }
        }

        private void WriteToken(Token token, XDocument tokensXml)
        {
           XElement parentNode = (token.IsSubToken)? tokensXml.Descendants(SubTokensNodeName).First() : tokensXml.Element(TokensNodeName);
           XElement node = new XElement(TokenNodeName);

           node.SetAttributeValue(KeyAttributeName, token.Key);
           node.SetAttributeValue(ValueAttributeName, token.Value); 

           if(!string.IsNullOrEmpty(token.Description))
           {
                node.SetAttributeValue(DescriptionAttributeName, token.Description);
           }

           if (token.IsPassword)
            {
                node.SetAttributeValue(PasswordAttributeName, "true"); 

                if (!string.IsNullOrEmpty(token.UserName))
                {
                    node.SetAttributeValue(UserNameAttributeName, token.UserName);
                }
           }

           parentNode.Add(node);
        }

        private XElement FindXmlTokenNode(Token token, XDocument tokensXml)
        {
            return tokensXml.Descendants(TokenNodeName)
                .Where(x => token.Key.Equals(x?.Attribute(KeyAttributeName)?.Value))
                .SingleOrDefault();
        }
    }
}
