﻿using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Xml.Linq;
using TokenManager.Core.Model;
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
           XElement parentNode = (token.IsSubToken)? tokensXml.Descendants(Xml.SubTokensNodeName).First() : tokensXml.Element(Xml.TokensNodeName);
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
                .Where(x => token.Key.Equals(x?.Attribute(Xml.KeyAttributeName)?.Value))
                .SingleOrDefault();
        }
    }
}
