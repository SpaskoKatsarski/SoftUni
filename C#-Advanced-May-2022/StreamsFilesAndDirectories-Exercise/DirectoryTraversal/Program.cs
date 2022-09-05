namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            //we need the extension for every file

            Dictionary<string, List<FileInfo>> extensionsInfo = new Dictionary<string, List<FileInfo>>();

            foreach (var file in files)
            {
                //information for the file -> extension
                FileInfo fileInfo = new FileInfo(file);
                string extension = fileInfo.Extension;

                if (!extensionsInfo.ContainsKey(extension))
                {
                    extensionsInfo.Add(extension, new List<FileInfo>());
                }

                extensionsInfo[extension].Add(fileInfo);
            }

            StringBuilder result = new StringBuilder();

            foreach (var item in extensionsInfo.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                string extension = item.Key;

                List<FileInfo> filesInfo = item.Value;

                result.AppendLine(extension);

                foreach (var file in filesInfo.OrderByDescending(f => f.Length))
                {
                    result.AppendLine($"--{file.Name}.{extension} - {file.Length / 1024}kb");
                }
            }

            return result.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            //we have to write textContent to the text file report.txt on the desktop
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + reportFileName;

            File.WriteAllText(path, textContent);
        }
    }
}
