using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Text;

namespace TokenManager.Core.Services
{

    [Export(typeof(ILogger))]
    public class Logger : TokenManager.Core.Services.ILogger
    {
        public void Info(string text)
        {
            Console.Out.WriteLine("test");
        }
    }
}
