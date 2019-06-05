using System.Collections.Generic;
using Lexer.Models;

namespace Service.Lexer
{
    public interface ILexerService
    {
         ICollection<Token> Show(string substance, int count);
         ICollection<Token> ShowAllTokens(string substance, int count);
    }
}