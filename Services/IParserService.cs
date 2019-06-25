using System.Collections.Generic;
using Lexer.Models;

namespace Lexer.Services
{
    public interface IParserService
    {
         bool Show(string substance, int count);
         ICollection<ITokenParser> ShowAllTokens(string substance, int count);
    }
}