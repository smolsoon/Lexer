using System.Linq;
using Lexer.Models;

namespace Lexer
{
    public class TokenNumber : CheckRegex, ILexer
    {
        public Token Show(string substance, int count)
        {
            for (var i = count; i < substance.Length; i++)
            {
                var @char = substance.ElementAt(i);

                if (Letter(@char)) return new Token(substance.Substring(count, i - count), TokenType.Number);

                if (Number(@char)) continue;

                if (Operator(@char)) return new Token(substance.Substring(count, i - count), TokenType.Number);

                if (Bracket(@char)) return new Token(substance.Substring(count, i - count), TokenType.Number);

                if (Dot(@char))
                {
                    var finder = new TokenFloat();
                    var token = finder.Show(substance, count);

                    if (token.Type == TokenType.BadChar)
                    {
                        return new Token(substance.Substring(count, i - count), TokenType.Number);
                    }
                    else
                    {
                        return token;
                    }
                }

                if (Whitespace(@char)) return new Token(substance.Substring(count, i - count), TokenType.Number);

                return new Token(substance.Substring(count, i - count), TokenType.Number);
            }

            return new Token(substance.Substring(count), TokenType.Number);
        }
    }
}