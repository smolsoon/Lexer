using System;
using System.Collections.Generic;
using Lexer.Models;
using Lexer.Parser;
using Lexer.Services;
using Services.Lexer;

namespace Lexer 
{
    public class Program 
    {
        private static void Main (string[] args) 
        {
            #region Lexer   
            // ICollection<Token> _tokens = new List<Token>();

            // var file = new FileReader();
            // var fullContext = file.Text;
            // var tokenFinder = new LexerService(_tokens);

            // int count = 0;
            // foreach (var context in fullContext)
            // {
            //     if(context != ""){
            //         var tokens = tokenFinder.Show(context,count);
            //         Console.WriteLine("Token: " + context); 
            //         foreach (var token in tokens) {
            //             Console.WriteLine("\t" + token.Value + "\t type: " + token.Type);
            //         }  
            //         tokens.Clear();
            //     }else
            //     {
            //         Console.WriteLine("Token: it's a white space"); 
            //     }

            // }

            #endregion

            #region Parser

            ICollection<ITokenParser> _tokens = new List<ITokenParser> ();
            var file = new FileReader ();
            var sentence = file.Text;

            var parserService = new ParserService (_tokens);
            int count = 0;
            foreach (var item in sentence)
            {
                System.Console.WriteLine ("----------------------------------------------------");
                if (item != "")
                {
                    Console.WriteLine ("Expression: " + item);
                    var tokenSentence = parserService.Show (item, count);

                    if (tokenSentence)
                    {
                        int i = 0;

                        Context context = new Context (_tokens);
                        var parserSentenceExpression = new ParserSentenceExpression ();
                        bool syntaticAnalysis = parserSentenceExpression.Represent (context);

                        int coun = 0;
                        foreach (var token in _tokens)
                        {
                            if((token.Factor == "(") || (token.Factor  == ")"))
                            {
                                ++coun;
                            }

                            if(coun == _tokens.Count)
                            {
                                syntaticAnalysis = false;
                            }
                        }
                        
                        if (syntaticAnalysis)
                        {
                            foreach (var token in _tokens)
                            {
                                Console.WriteLine ("Token " + ++i + ":" + "\t" +
                                token.Factor + "\t" + token.GetType ());
                            }

                            Console.WriteLine ("Syntactic analysis : TRUE");
                        }
                        else
                        {
                            Console.WriteLine ("Syntactic analysis : FALSE");
                            if(syntaticAnalysis)
                                Console.WriteLine ("Bad token: \t" + context.BadToken.Factor);

                        }
                        _tokens.Clear ();
                    }
                    else
                    {
                        Console.WriteLine ("FALSE");
                    }
                        Console.WriteLine ();
                }
                else
                {
                    Console.WriteLine ("Expression: " + item);
                    System.Console.WriteLine ("Expression is empty");
                }
            }
        }
        #endregion
    }
}