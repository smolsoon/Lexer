using System;
using System.Collections.Generic;
using System.Linq;
using Lexer;
using Lexer.Models;
using Service.Lexer;

namespace Services.Lexer
{
    public class LexerService : CheckRegex, ILexerService 
    {
        private ICollection<Token> _tokens = new List<Token>();
        public LexerService(ICollection<Token> tokens)
        {
            _tokens = tokens;
        }

        public ICollection<Token> Show(string substance, int count)
            => ShowAllTokens(substance, count);

        public ICollection<Token> ShowAllTokens(string substance, int count)
        {
            for (count = 0; count < substance.Length; count++)
            {
                var @char = substance.ElementAt(count);

                if (Letter(@char))
                {
                    var token = new TokenId();
                    _tokens.Add(token.Show(substance,count));
                    count += _tokens.Last().Value.Length;
                    count--;
                    continue;
                }

                if (Number(@char))
                {
                    var token = new TokenNumber();
                    _tokens.Add(token.Show(substance,count));
                    count += _tokens.Last().Value.Length;
                    count--;
                    continue;
                }

                if (Operator(@char))
                {
                    _tokens.Add(new Token(@char.ToString(), TokenType.Operation));
                    continue;
                }

                if (Bracket(@char))
                {
                    _tokens.Add(new Token(@char.ToString(), TokenType.Bracket));
                    continue;
                }

                if (Dot(@char))
                {
                    _tokens.Add(new Token(@char.ToString(), TokenType.BadChar));
                    continue;
                }

                if (Whitespace(@char)) continue;
            }

            return _tokens;
        }
    }
}