using System;
using System.Collections.Generic;
using Lexer.Models;
using Services.Lexer;

namespace Lexer
{
    public class Program
    {
        private static void Main(string[] args)
        {            
            ICollection<Token> _tokens = new List<Token>();

            var file = new FileReader();
            var fullContext = file.Text;
            var tokenFinder = new LexerService(_tokens);

            int count = 0;
            foreach (var context in fullContext)
            {
                if(context != ""){
                    var tokens = tokenFinder.Show(context,count);
                    Console.WriteLine("Token: " + context); 
                    foreach (var token in tokens) {
                        Console.WriteLine("\t" + token.Value + "\t type: " + token.Type);
                    }  
                    tokens.Clear();
                }else
                {
                    Console.WriteLine("Token: it's a white space"); 
                }

            }
        }
    }
}
