namespace TokenManager.Core.ViewModel
{
    public class TokenViewModel
    {
        public string Token { get; set; }

        public string Value { get; set; }

        public bool IsSubToken { get; set; }

        public string Description { get; set; }

        public bool IsPassword { get; set; }

        public bool IsGlobal { get; set; }
    }
}
