using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenBadChar : ITokenParser
    {
        public TokenBadChar(string value)
        {
            Factor = value;
        }
        public string Factor { get; set; }
    }
}