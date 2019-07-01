using System.Linq;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class ParserSentenceExpression 
    {
        public bool Represent(Context context)
        {
            var bracket = true;
            for (var i = 0; i < context.Size; ++i)
            {
                var token = context.Input.ElementAt(i);
                if (token.GetType() == typeof(TokenNumber) || token.GetType() == typeof(TokenFloat) || 
                    token.GetType() == typeof(TokenId))
                {
                    if (context.Stack.Count == 0)
                    {
                        context.Stack.Push(token); continue;
                    }
                    if (context.Stack.Peek().GetType() == typeof(TokenOperator))
                        context.Stack.Push(token);
                    else
                    {
                        context.BadToken = token;
                        return false;
                    }
                    continue;
                }

                if (token.GetType() == typeof(TokenOperator))
                {
                    if (context.Stack.Count == 0 && bracket == false)
                    {
                        context.BadToken = token;
                        return false;
                    }
                    if (context.Stack.Count == 0 && bracket == true)
                    {
                        context.Stack.Push(token);
                        continue;
                    }
                    if (context.Stack.Peek().GetType() == typeof(TokenOperator))
                    {
                        context.BadToken = token;
                        return false;
                    }
                    if (context.Stack.Peek().GetType() == typeof(TokenNumber) ||
                        context.Stack.Peek().GetType() == typeof(TokenFloat) ||
                        context.Stack.Peek().GetType() == typeof(TokenId))
                        context.Stack.Push(token);
                    continue;
                }

                if (token.GetType() == typeof(TokenBracket) )
                {
                    var bracketExpression = new ParserBracketExpression(i);
                    if (bracketExpression.Represent(context))
                    {
                        i = bracketExpression.End;
                        bracket = true;
                        if(context.Stack.Count() != 0)
                            context.Stack.Push(bracketExpression._context.Stack.Peek());
                        continue;
                    }
                    else
                    {
                        context.BadToken = bracketExpression._context.BadToken;
                        return false;
                    }
                }

                if(!(token.GetType() == typeof(TokenBracket)))
                    return false;
                
                
                if(token.GetType() == typeof(TokenOtherChar))
                {
                    return false;
                }

                context.BadToken = token;
                return false;
            }

            if (context.Stack.Count == 0 && bracket)
                return true;
            if (context.Stack.Count == 0)
            {
                context.BadToken = new TokenBadChar("Empty");
                return false;
            }
            if (context.Stack.Peek().GetType() == typeof(TokenOperator) && bracket)
                return true;
            if (context.Stack.Peek().GetType() == typeof(TokenOperator))
                return false;
    
            return true;
        }
    }
}