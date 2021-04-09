using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using TokenManager.Core.Model;
using TokenManager.Core.Services;
using  Xml = TokenManager.Core.DomainServices.XmlConstants;

namespace TokenManager.Core.DomainServices
{
    public interface IDataSourceWritter
    {
        void WriteTokens(IEnumerable<Token> tokens, string filePath);
    }

    [Export(typeof(IDataSourceWritter))]
    internal class DataSourceWritter : IDataSourceWritter
    {
        private ITFSService _tfsService;

        [ImportingConstructor]
        public DataSourceWritter(ITFSService tfsService)
        {
            _tfsService = tfsService;
        }

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
                                UpdateToken(token, xmlNode);

                                token.IsDirty = false;
                                token.Action = Model.Action.None;
                            }
                        }
                    }
                }

                _tfsService.Checkout(filePath);
                tokensXml.Save(filePath);
            }
        }

        private void UpdateToken(Token token, XElement node)
        {
            node.SetAttributeValue(Xml.ValueAttributeName, token.Value);

            var oldDescriptionValue = ReadAttribute(node, Xml.DescriptionAttributeName); 
            if (!string.IsNullOrEmpty(token.Description))
            {
                node.SetAttributeValue(Xml.DescriptionAttributeName, token.Description);
            }
            else if (!string.IsNullOrEmpty(oldDescriptionValue))
            {
                node.Attribute(Xml.DescriptionAttributeName).Remove();
            }

            if (token.IsPassword)
            {
                var oldUserNameValue = ReadAttribute(node, Xml.UserNameAttributeName);
                if (!string.IsNullOrEmpty(token.UserName))
                {
                    node.SetAttributeValue(Xml.UserNameAttributeName, token.UserName);
                }
                else if (!string.IsNullOrEmpty(oldUserNameValue))
                {
                    node.Attribute(Xml.UserNameAttributeName).Remove();
                }
            }
        }

        private void WriteToken(Token token, XDocument tokensXml)
        {
           XElement parentNode = (token.IsSubtoken)? tokensXml.Descendants(Xml.SubtokensNodeName).First() : tokensXml.Element(Xml.TokensNodeName);
           XElement node = new XElement(Xml.TokenNodeName);

           node.SetAttributeValue(Xml.KeyAttributeName, token.Key);
           node.SetAttributeValue(Xml.ValueAttributeName, token.Value); 

           if(!string.IsNullOrEmpty(token.Description))
           {
                node.SetAttributeValue(Xml.DescriptionAttributeName, token.Description);
           }

           if (token.IsPassword)
            {
                node.SetAttributeValue(Xml.PasswordAttributeName, "true"); 

                if (!string.IsNullOrEmpty(token.UserName))
                {
                    node.SetAttributeValue(Xml.UserNameAttributeName, token.UserName);
                }
           }

           parentNode.Add(node);
        }

        private XElement FindXmlTokenNode(Token token, XDocument tokensXml)
        {
            return tokensXml.Descendants(Xml.TokenNodeName)
                .Where(x => token.Key.Equals(x.Attribute(Xml.KeyAttributeName).Value))
                .SingleOrDefault();
        }

        private string ReadAttribute(XElement xElement, string attributeName)
        {
            var attribute = xElement.Attributes().Where(x => x.Name.LocalName.Equals(attributeName, System.StringComparison.OrdinalIgnoreCase)).SingleOrDefault();
            if (attribute != null)
            {
                return attribute.Value;
            }

            return string.Empty;
        }
    }
}
