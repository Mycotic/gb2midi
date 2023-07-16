using System;
namespace gb2midi
{
	public class GbReader
	{
		private StreamReader streamReader;
		public GbReader(Stream inStream)
		{
			this.streamReader = new StreamReader(inStream);
		}

		private void ReadFromStream()
		{
			string line;
            while ((line = streamReader.ReadLine()) != null)
			{

			}
        }
	}
}

