using System;
using System.Collections.Generic;
using TokenManager.Core.Model;

namespace TokenManager.Core.Services
{
    public interface IDataSourceLoader
    {
        IList<Token> ReadTokens(string filePath, bool isRoot);
    }
}
