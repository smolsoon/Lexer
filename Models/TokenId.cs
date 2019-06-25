using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenId : ITokenParser
    {
        public TokenId(string value)
        {
            Factor = value;
            Value = value;
        }
        public string Value { get; set; }
        public string Factor { get; set; }
    }
}