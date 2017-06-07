namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class DirectoryTraversal
	{
		static void Main(string[] args)
		{
			var inputDirectory = Console.ReadLine();
			var dictionary = new Dictionary<string, Dictionary<string, double>>();
			var files = Directory.GetFiles(inputDirectory);
			foreach (var file in files)
			{
				var fileName = Path.GetFileName(file);
				var extension = Path.GetExtension(fileName);
				double size = (double)new FileInfo(file).Length / 1000;
				
				if (!dictionary.ContainsKey(extension))
				{
					dictionary.Add(extension, new Dictionary<string, double>());
					dictionary[extension].Add(fileName,size);
				}
				else
				{
					dictionary[extension].Add(fileName, size);
				}
				string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ @"\"+ "result.txt";
				using (StreamWriter writer = new StreamWriter(path))
				{
					foreach (var types in dictionary.OrderByDescending(c => c.Value.Count)) 
					{
						writer.WriteLine($"{types.Key}");
						foreach (var outputFile in types.Value.OrderBy(c=> c.Key))
						{
							writer.WriteLine($"--{outputFile.Key} - {outputFile.Value} kb");
						}
					}
				}
            }
		}
	}
}
