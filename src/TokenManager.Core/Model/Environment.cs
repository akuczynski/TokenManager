namespace TokenManager.Core.Model
{
    public class Environment
    {
        public string Name { get; set; }

        /// <summary>
        /// FilePath to env token.xml file 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// True for the main token.xml file on the root folder 
        /// </summary>
        public bool IsRoot { get; set; }
    }
}
