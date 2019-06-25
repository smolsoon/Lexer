using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenNumber : ITokenParser
    {
        public TokenNumber(string value)
        {
            Factor = value;
            Value = int.Parse(value);
        }
        public int Value { get; set; }
        public string Factor { get; set; }
    }
}