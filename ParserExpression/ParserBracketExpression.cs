using System;
using System.Linq;
using Lexer.Models;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class ParserBracketExpression
    {
        public int Start { get; set; }
        public int End { get; set; }
        public Context _context{ get; set; }
        public ParserBracketExpression(int i)
        {
            Start = ++i;
        }

        public bool Represent(Context context)
        {
            var counter = 1;
            for (var i = Start; i < context.Size; i++)
            {
                var token = context.Input.ElementAt(i);
                if (token.GetType() == typeof(TokenBracket) && token.Factor == "(")
                {
                    counter++;
                    continue;
                }
                if (token.GetType() == typeof(TokenBracket) && token.Factor == ")")
                    counter--;

                if (counter == 0)
                {
                    var parserSentenceExpression = new ParserSentenceExpression();
                    End = i;
                    var tokenList = context.GetTokens(Start, End);
                    _context = new Context(tokenList);
                    if(context.Stack.Count() != 0)
                        _context.Stack.Push(context.Stack.Peek());
                    return parserSentenceExpression.Represent(_context);
                }

                if(token.GetType() == typeof(TokenBracket))
                {
                    
                }
            }
            _context = context;
            _context.BadToken = new TokenBadChar("')' do not exists");
            return false;
        }
    }
}