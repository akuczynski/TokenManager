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
                    var xmlNode = FindXmlTokenNode(token, tokensXml);
                    if (xmlNode != null)
                    {
                        if (token.Action == Model.Action.Delete)
                        {
                            xmlNode.Remove();
                        }
                    }
                }

                tokensXml.Save(filePath);
            }
        }

        private XElement FindXmlTokenNode(Token token, XDocument tokensXml)
        {
            return tokensXml.Descendants("token").Where(x => token.Key.Equals(x?.Attribute("key")?.Value)).SingleOrDefault();
        }
    }
}
