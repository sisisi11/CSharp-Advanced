namespace SlicingFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    public class SlicingFile
	{
		static void Main(string[] args)
		{

			var n = int.Parse(Console.ReadLine());
			var sourceFile = Console.ReadLine();
			var destinationDirectory = Console.ReadLine();
			Slice(sourceFile, destinationDirectory, n);
			var files = Directory.GetFiles(destinationDirectory);
			var wantedFiles = new List<string>();
			foreach (var file in files)
			{
				if (file.Contains("Part"))
				{
					wantedFiles.Add(file);
				}
			}
		}
		private static void Assemble(List<string> files, string destinationDirectory)
		{
			var example = files.FirstOrDefault();
			var regex = new Regex(@"([.]\w{1,5})");
			var match = regex.Match(example);
			var extension = match.Groups[1];
			var outputFilePath = destinationDirectory + "assembled" + extension;
			using (var outputStream = File.Create(outputFilePath))
			{
				foreach (var inputFilePath in files)
				{
					using (var inputStream = File.OpenRead(inputFilePath))
					{
						inputStream.CopyTo(outputStream);
					}
					Console.WriteLine("The file {0} has been processed.", inputFilePath);
				}
			}
		}
		private static void Slice(string sourceFile, string destinationDirectory, int parts)
		{
			string inputFile = sourceFile; 
			FileStream fs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
			int numberOfFiles = parts;
			int sizeOfEachFile = (int)Math.Ceiling((double)fs.Length / numberOfFiles);
			for (int i = 1; i <= numberOfFiles; i++)
			{
				string extension = Path.GetExtension(inputFile);
				FileStream outputFile = new FileStream(destinationDirectory + "Part-" + $"{i - 1}" + ".gz", FileMode.Create, FileAccess.Write);

					int bytesRead = 0;
					byte[] buffer = new byte[sizeOfEachFile];
					if ((bytesRead = fs.Read(buffer, 0, sizeOfEachFile)) > 0)
					{
						outputFile.Write(buffer, 0, bytesRead);
					}
				outputFile.Close();
			}
			fs.Close();
		}
	}
}

