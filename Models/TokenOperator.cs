using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenOperator : ITokenParser
    {
        public TokenOperator(string value)
        {
            Factor = value;
        }
        public string Factor { get; set; }
    }
}