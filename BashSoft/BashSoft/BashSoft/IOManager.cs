using System;
using System.Collections.Generic;
using System.IO;

namespace BashSoft
{
    public static class IOManager
    {

        public static void TraverseDirectory(string path)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentication = path.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(path);

            while (subFolders.Count != 0)
            {
                var currentPath = subFolders.Dequeue();
                int identication = currentPath.Split('\\').Length - initialIdentication;
                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identication), currentPath));

                foreach (var file in Directory.GetFiles(currentPath))
                {
                    var indexOflastSlash = file.LastIndexOf("\\");
                    var fileName = file.Substring(indexOflastSlash);
                    OutputWriter.WriteMessageOnNewLine(new string('-', indexOflastSlash) + fileName);
                }
                foreach (var directoryPath in Directory.GetDirectories(currentPath))
                {
                    subFolders.Enqueue(directoryPath);
                }
            }
        }
    }
}
