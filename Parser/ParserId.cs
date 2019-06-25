using System.Linq;
using Lexer.Models;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class ParserId : CheckRegex, IParser
    {
        public ITokenParser Show(string substance, int count)
        {
            for (var i = count; i < substance.Length; i++)
            {
                var @char = substance.ElementAt(i);

                if (Letter(@char)) continue;

                if (Number(@char)) continue;

                if (Operator(@char)) 
                    return new TokenId(substance.Substring(count, i - count));
                
                if (OtherChar(@char)) 
                    return new TokenId(substance.Substring(count, i - count));

                if (Bracket(@char)) 
                    return new TokenId(substance.Substring(count, i - count));

                if (Dot(@char)) 
                    return new TokenId(substance.Substring(count, i - count));

                if (Whitespace(@char))
                    return new TokenId(substance.Substring(count, i - count));

                return new TokenId(substance.Substring(count, i - count));
            }

            return new TokenId(substance.Substring(count));
        }
    }
}