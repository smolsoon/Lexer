using System.Text.RegularExpressions;
using Lexer.Models;


namespace Lexer
{
    public class CheckRegex
    {
        public bool Letter(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "([a-zA-Z])");
        }

        public bool Number(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "([0-9])");
        }

        public bool Operator(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "[\\+\\-\\*\\/\\=]");
        } 

        public bool Bracket(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "[\\(\\)]");
        }

        public bool Dot(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "([.])");
        }

        public bool Whitespace(char variable)
        {
            return string.IsNullOrWhiteSpace(variable.ToString());
        }

        public bool OtherChar(char variable)
        {
            return Regex.IsMatch(variable.ToString(), "[~@#$%^&]");
        }
    }
}