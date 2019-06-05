using System.Linq;
using Lexer.Models;



namespace Lexer
{
    public class TokenFloat : CheckRegex, ILexer
    {
        public Token Show(string substance, int count)
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
                        return new Token(substance.Substring(count, i-count), TokenType.FloatNumber);
                    }
                    else
                    {
                        return new Token(substance.Substring(count, i-count), TokenType.BadChar);
                    }
                }

                if (Number(@char))
                {
                    if (dotcount == 1) isFloat = true;
                    continue;
                }

                if (Operator(@char)) return new Token(substance.Substring(count, i - count), TokenType.FloatNumber);

                if (Bracket(@char)) return new Token(substance.Substring(count, i - count), TokenType.FloatNumber);

                if (Dot(substance.ElementAt(i)))
                {
                    if (dotcount >= 1)
                        return new Token(substance.Substring(count, i-count), TokenType.FloatNumber);
                    dotcount++;
                    continue;
                }

                if (Whitespace(@char)) return new Token(substance.Substring(count, i - count), TokenType.FloatNumber);

                return new Token(substance.Substring(count, i - count), TokenType.FloatNumber); 
            }

            return new Token(substance.Substring(count), TokenType.FloatNumber);
        }
    }
}