using System.Linq;
using Lexer.Models;

namespace Lexer
{
    public class LexerId : CheckRegex, ILexer
    {
        public Token Show(string substance, int count)
        {
             for (var i = count; i < substance.Length; i++)
            {
                var @char = substance.ElementAt(i);

                if (Letter(@char)) continue;

                if (Number(@char)) continue;

                if (Operator(@char)) 
                    return new Token(substance.Substring(count, i - count), TokenType.Id);

                if (Bracket(@char)) 
                    return new Token(substance.Substring(count, i - count), TokenType.Id);

                if (Dot(@char)) 
                    return new Token(substance.Substring(count, i - count), TokenType.Id);

                if (Whitespace(@char))
                    return new Token(substance.Substring(count, i - count), TokenType.Id);

                return new Token(substance.Substring(count, i - count), TokenType.Id);
            }

            return new Token(substance.Substring(count), TokenType.Id);
        }
    }
}