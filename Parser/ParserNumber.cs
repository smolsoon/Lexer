using System.Linq;
using Lexer.Models;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class ParserNumber : CheckRegex, IParser
    {
        public ITokenParser Show(string substance, int count)
        {
            for (var i = count; i < substance.Length; i++)
            {
                var @char = substance.ElementAt(i);

                if (Letter(@char)) 
                    return new TokenNumber(substance.Substring(count, i - count));

                if (Number(@char)) 
                    continue;

                if (Operator(@char)) 
                    return new TokenNumber(substance.Substring(count, i - count));
    
                if (Bracket(@char)) 
                    return new TokenNumber(substance.Substring(count, i - count));

                if (OtherChar(@char)) 
                    return new TokenNumber(substance.Substring(count, i - count));

                if (Dot(@char))
                {
                    var finder = new ParserFloat();
                    var token = finder.Show(substance, count);

                    if (token.GetType() == typeof(TokenBadChar))
                    {
                        return new TokenNumber(substance.Substring(count, i - count));
                    }
                    else
                    {
                        return token;
                    }
                }

                if (Whitespace(@char)) return new TokenNumber(substance.Substring(count, i - count));
                    return new TokenNumber(substance.Substring(count, i - count));
            }
                return new TokenNumber(substance.Substring(count));
        }
    }
}