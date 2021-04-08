namespace TokenManager.Core.Model
{
    public enum Action
    {
        None, 
        Insert,
        Update, 
        Delete,

        TokenValueAssigment
    }

    public class Token
    {
        public string Key { get; set; }

        public string Value { get; set; }
    
        public string Description { get; set; }

        public bool IsPassword { get; set; }

        public string UserName { get; set; }

        public bool IsSubToken { get; set; }

        public Action Action { get; set; } 

        public bool IsDirty { get; set; }
    }

    public class EmptyToken : Token
    {

    }
}
