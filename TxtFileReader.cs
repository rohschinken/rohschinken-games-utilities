namespace RGUtility
{
	public static class TxtFileReader
	{
		public static string[] Load (string fileName)
		{
			return System.IO.File.ReadAllLines(@fileName);
		}
	}
}