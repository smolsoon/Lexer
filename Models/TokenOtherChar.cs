using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenOtherChar : ITokenParser
    {
        public TokenOtherChar(string value)
        {
            Factor = value;
        }
        public string Factor { get; set; }
    }
}