using System.Collections.Generic;
using System.Linq;
using Lexer.Models;
using Lexer.ParserToken;

namespace Lexer.Parser
{
    public class Context
    {
        public ICollection<ITokenParser> Input { get; set; }
        public Stack<ITokenParser> Stack { get; set; }
        public ITokenParser BadToken { get; set; }
        public int Size { get; set; }
        public bool Bracket { get; set; }

        public Context(ICollection<ITokenParser> input)
        {
            Input = new List<ITokenParser>(input);
            Stack = new Stack<ITokenParser>();
            Size = input.Count();
            Bracket = false;
        }

        public ICollection<ITokenParser> GetTokens(int start, int end)
        {
            var tokens = new List<ITokenParser>();
            for (; start < end; start++) 
                tokens.Add(Input.ElementAt(start));
                
            return tokens;
        }
    }
}