using System.Linq;
using Lexer.Models;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class ParserFloat : CheckRegex, IParser
    {
        public ITokenParser Show(string substance, int count)
        {
            var dotcount = 0;
            var isFloat = false;
            for (var i = count; i < substance.Length; i++)
            {
                var @char = substance.ElementAt(i);

                if (Letter(@char))
                {
                    if (isFloat)
                    {
                        return new TokenFloat(substance.Substring(count, i-count));
                    }
                    else
                    {
                        return new TokenFloat(substance.Substring(count, i-count));
                    }
                }

                if (Number(@char))
                {
                    if (dotcount == 1) isFloat = true;
                    continue;
                }

                if (Operator(@char)) return new TokenFloat(substance.Substring(count, i - count));

                if (Bracket(@char)) return new TokenFloat(substance.Substring(count, i - count));
                
                if (OtherChar(@char)) return new TokenFloat(substance.Substring(count, i - count));

                if (Dot(substance.ElementAt(i)))
                {
                    if (dotcount >= 1)
                        return new TokenFloat(substance.Substring(count, i-count));
                    dotcount++;
                    continue;
                }

                if (Whitespace(@char)) return new TokenFloat(substance.Substring(count, i - count));

                return new TokenFloat(substance.Substring(count, i - count));
            }

            return new TokenFloat(substance.Substring(count));
        }
    }
}