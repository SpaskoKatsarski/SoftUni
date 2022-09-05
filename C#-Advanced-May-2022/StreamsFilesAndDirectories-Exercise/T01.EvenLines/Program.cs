namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (var reader = new StreamReader(inputFilePath))
            {
                List<string> list = new List<string>();

                string line = reader.ReadLine();

                int count = 0;

                while (true)
                {
                    if (line == null)
                    {
                        break;
                    }

                    //{'-', ', ', '. ', '! ', '? '}
                    line = line.Replace('-', '@')
                        .Replace(',', '@')
                        .Replace('.', '@')
                        .Replace('!', '@')
                        .Replace('?', '@');

                    line = string.Join(' ', line.Split(' ').Reverse());

                    if (count % 2 == 0)
                    {
                        list.Add(line);
                    }

                    line = reader.ReadLine();
                    count++;
                }

                StringBuilder sb = new StringBuilder();

                foreach (var sentence in list)
                {
                    sb.Append(sentence + "\r\n");
                }

                return sb.ToString();
            }
        }
    }
}
