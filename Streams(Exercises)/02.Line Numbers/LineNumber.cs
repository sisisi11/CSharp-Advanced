namespace LineNumbers
{
    using System.IO;
    public class LineNumber
	{
		static void Main(string[] args)
		{
			using (StreamReader reader = new StreamReader(@"../../hello.txt"))
			{
				using (StreamWriter writer = new StreamWriter(@"../../hello2.txt"))
				{
					string line = reader.ReadLine();
					var counter = 1;
					while (line != null)
					{
						writer.WriteLine($"{counter} {line}");
						counter++;
						line = reader.ReadLine();
					}
				}
			}
		}
	}
}
