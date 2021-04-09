namespace TokenManager.Core.Services
{
    using System.ComponentModel.Composition;

    using TokenManager.Core.DomainServices;

    public interface ITFSService
    {
        void Checkout(string filePath);
    }

    [Export(typeof(ITFSService))]
    internal class TFSService : ITFSService
    {
        private string _pathToTFS;

        [ImportingConstructor]
        public TFSService(IConfiguration configuration)
        {
            _pathToTFS = configuration.Get("PathToTFS");
        }

        public void Checkout(string filePath)
        {
            if (string.IsNullOrEmpty(this._pathToTFS))
            {
                return;
            }

            CallCommmand("checkout", filePath);
        }


        private void CallCommmand(string command, string filePath)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = _pathToTFS;
            startInfo.Arguments = string.Format("{0} {1}", command, filePath);
            process.StartInfo = startInfo;
            process.Start();
            process.WaitForExit();
        }
    }
}
