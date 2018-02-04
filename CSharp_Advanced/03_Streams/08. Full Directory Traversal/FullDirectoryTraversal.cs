namespace _08.Full_Directory_Traversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FullDirectoryTraversal
    {
        public static void Main()
        {
            var sourcePath = "../../Files/";
            var destinationPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var filesDict = new Dictionary<string, Dictionary<string, long>>();

            Console.WriteLine($"Searching directory '{sourcePath}' (including sub-directories)");
            SearchDirectory(sourcePath, destinationPath, filesDict);
        }

        private static void SearchDirectory(string sourcePath, string destinationPath, Dictionary<string, Dictionary<string, long>> filesDict)
        {
            var filesInDirectory = Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories);

            foreach (var file in filesInDirectory)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var name = fileInfo.Name;
                var length = fileInfo.Length;

                if (!filesDict.ContainsKey(extension))
                {
                    filesDict[extension] = new Dictionary<string, long>();
                }

                if (!filesDict[extension].ContainsKey(name))
                {
                    filesDict[extension][name] = length;
                }
            }

            var filesDictSorted = filesDict
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            Console.WriteLine($@"Result saved in '{destinationPath}\reportFullSearch.txt'");

            using (var report = new StreamWriter($"{destinationPath}/reportFullSearch.txt"))
            {
                foreach (var kvp in filesDictSorted)
                {
                    var extension = kvp.Key;
                    var files = filesDict[extension].OrderByDescending(x => x.Value);

                    report.WriteLine(extension);

                    foreach (var file in files)
                    {
                        report.WriteLine($"--{file.Key} - {(double)file.Value / 1024:f3} kb");
                    }
                }
            }
        }
    }
}