using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace Lexer
{
    public class FileReader
    {
        public FileReader()
        {
            Text = new List<string>();
            ReadFile().Wait(5000);
        }

        public ICollection<string> Text { get; set; }

        public async Task ReadFile()
        {
            var filePath = "file.txt";
            ClearText();
            try
            {
                using (var streamReader = new StreamReader(filePath))
                {
                    while (streamReader.Peek() >= 0)
                    {
                        var line = await streamReader.ReadLineAsync();
                        Text.Add(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        public void PrintText()
        {
            foreach (var line in Text) Console.WriteLine(line);
        }

        private void ClearText()
        {
            Text = new List<string>();
        }
    }
    
}