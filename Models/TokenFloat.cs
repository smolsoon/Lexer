using System.Globalization;
using Lexer.Models;

namespace Lexer.ParserToken
{
    public class TokenFloat : ITokenParser
    {
        public TokenFloat(string value)
        {
            Factor = value;
            Value = float.Parse(value,CultureInfo.InvariantCulture.NumberFormat);
        }
        public float Value { get; set; }
        public string Factor { get; set; }
    }
}