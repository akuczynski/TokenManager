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
           XElement parentNode = (token.IsSubToken)? tokensXml.Element("subtokens") : tokensXml.Element("tokens");
           XElement node = new XElement("token");

           node.SetAttributeValue("key", token.Key);
           node.SetAttributeValue("value", token.Value); 

           if(!string.IsNullOrEmpty(token.Description))
           {
                node.SetAttributeValue("description", token.Description);
           }

           if (token.IsPassword)
            {
                node.SetAttributeValue("password", "true"); 

                if (!String.IsNullOrEmpty(token.UserName))
                {
                    node.SetAttributeValue("userName", token.UserName);
                }
           }

           parentNode.Add(node);
        }

        private XElement FindXmlTokenNode(Token token, XDocument tokensXml)
        {
            return tokensXml.Descendants("token").Where(x => token.Key.Equals(x?.Attribute("key")?.Value)).SingleOrDefault();
        }
    }
}
