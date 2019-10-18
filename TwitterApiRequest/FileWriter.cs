using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TwitterApiRequest
{
    public class FileWriter
    {
        public void WriterOnFile(string text)
        {
            StreamWriter writer = new StreamWriter(@"D:\twitter2.txt", true);
            using (writer)
            {
                // Escreve uma nova linha no final do arquivo
                writer.WriteLine(text);
            }
        }
    }
}
