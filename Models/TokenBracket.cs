using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenBracket : ITokenParser
    {
        public TokenBracket(string value)
        {
            Factor = value;
            IsOpen = Factor == "(";
        }
        public bool IsOpen { get; set; }
        public string Factor { get; set; }
    }
}