namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class WordCount
	{
		static void Main(string[] args)
		{
		 
			using (StreamReader readerSearchedWords = new StreamReader("../../words.txt"))
			{
				using (StreamReader readerText = new StreamReader("../../text.txt"))
				{
					string line = readerText.ReadLine();
					var lines = "";
					while (line != null)
					{
						lines += line.ToLower();
						line = readerText.ReadLine();
					}
					var words  = lines.Split(new char[] {' ', ',', '.', '?', '!', '-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
					string searchWord = readerSearchedWords.ReadLine();
					var data = new Dictionary<string, int>();
					while (searchWord != null)
					{
						// Add the word which is needed to search so I can easier take count.
						data.Add(searchWord.ToLower(), 0);
						searchWord = readerSearchedWords.ReadLine();
					}
					
					using (StreamWriter results = new StreamWriter(@"../../result.txt"))
					{
						foreach (var word in words)
						{
							if (data.ContainsKey(word))
							{
								data[word] += 1;
							}
						
						}

						foreach (var matchedWord in data.OrderByDescending(c => c.Value))
						{
							results.WriteLine($"{matchedWord.Key} - {matchedWord.Value}");
							
						}
					}
				}
			}
		}
	}
}
