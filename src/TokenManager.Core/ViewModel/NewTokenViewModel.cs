namespace TokenManager.Core.ViewModel
{
    public class NewTokenViewModel
    {
        public string Token { get; set; }

        public bool IsSubToken { get; set; }

        public string Environment { get; set; }

        public bool IsGlobal { get; set; }

        public bool IsPassword { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public string UserName { get; set; }
    }
}
