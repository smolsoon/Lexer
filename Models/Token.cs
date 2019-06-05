namespace Lexer.Models
{
     public enum TokenType
    {
        Id, 
        Number,
        FloatNumber,
        Operation,
        Bracket,
        BadChar
    }

    public class Token
    {
        public string Value { get; set; }
        public TokenType Type { get; set; }
        public Token(string value, TokenType type)
        {
            Value = value;
            Type = type;
        }
    }
}