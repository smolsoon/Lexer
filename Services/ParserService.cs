using System;
using System.Collections.Generic;
using System.Linq;
using Lexer.Models;
using Lexer.Parser;
using Lexer.ParserToken;

namespace Lexer.Services
{
    public class ParserService : CheckRegex, IParserService
    {
        private ICollection<ITokenParser> _tokens = new List<ITokenParser>();
        public ParserService(ICollection<ITokenParser> tokens)
        {
            _tokens = tokens;
        }

        public bool Show(string substance, int count)
        {
            ShowAllTokens(substance, count);
            return true;
        }

        public ICollection<ITokenParser> ShowAllTokens(string substance, int count)
        {
            for (count = 0; count < substance.Length; count++)
            {
                var @char = substance.ElementAt(count);

                if (Letter(@char))
                {
                    var token = new ParserId();
                    _tokens.Add(token.Show(substance,count));
                    count += _tokens.Last().Factor.Length;
                    count--;
                    continue;
                }

                if (Number(@char))
                {
                    var token = new ParserNumber();
                    _tokens.Add(token.Show(substance,count));
                    count += _tokens.Last().Factor.Length;
                    count--;
                    continue;
                }

                if (Operator(@char))
                {
                    _tokens.Add((new TokenOperator(@char.ToString())));
                    continue;
                }

                if (Bracket(@char))
                {
                    _tokens.Add(new TokenBracket(@char.ToString()));
                    continue;
                }

                if (Dot(@char))
                {
                     _tokens.Add(new TokenBadChar(@char.ToString()));
                    continue;
                }

                if(OtherChar(@char))
                {
                     _tokens.Add(new TokenOtherChar(@char.ToString()));
                    continue;
                }

                if (Whitespace(@char)) continue;
            }

            return _tokens;
        }
    }
}