namespace LineNumbers
{
    using System.IO;
    public class LineNumbers
    {
        static void Main(string[] args)
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            var reader = new StreamReader(inputFilePath);

            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);

                using (writer)
                {
                    int lineNum = 1;

                    string currentLine;

                    while ((currentLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{lineNum}. {currentLine}");

                        lineNum++;
                    }
                }
            }
        }
    }
}