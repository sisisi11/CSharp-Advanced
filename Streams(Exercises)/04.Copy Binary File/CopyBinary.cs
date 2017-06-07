namespace CopyBinaryFile
{
    using System.IO;
    public class CopyBinary
	{
		static void Main(string[] args)
		{
			using (var sourceImage = new FileStream(@"../../twitch.jpg", FileMode.Open))
			{
				using (var result = new FileStream(@"../../result.jpg", FileMode.Create))
				{
					byte[] buffer = new byte[4096];
					while (true)
					{
						int readBytes = sourceImage.Read(buffer, 0, buffer.Length );
						if (readBytes == 0)
						{
							break;
						}
						result.Write(buffer, 0, readBytes);
					}
				}
			}
		}
	}
}
