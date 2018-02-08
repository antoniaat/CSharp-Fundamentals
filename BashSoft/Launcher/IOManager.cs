using System;
using System.Collections.Generic;
using System.IO;

namespace Launcher
{
    public static class IOManager
    {
        public static void TraverseDirectory(string path)
        {
            //OutputWriter.WriteEmptyLine();
            int initialIdentation = path.Split('\\').Length;
            var subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                subFolders.Dequeue();
                Console.WriteLine(path);
                var tokens = path.Split('\\');
                foreach (var token in tokens)
                {
                    subFolders.Enqueue(token);
                }
            }

            var currentPath = subFolders.Dequeue();
            var identation = currentPath.Split('\\').Length - initialIdentation;

            Console.WriteLine(currentPath);

            foreach (var directoryPath in Directory.GetDirectories(currentPath))
            {
                subFolders.Enqueue(directoryPath);
            }

            OutputWriter.WriteMessageOnNewLine(string.Format($"{new string('-', identation)}{currentPath}"));
        }


    }
}
