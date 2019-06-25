using Lexer.Models;

namespace Lexer
{
    public interface IParser
    {
        ITokenParser Show (string substance , int count);
    }
}