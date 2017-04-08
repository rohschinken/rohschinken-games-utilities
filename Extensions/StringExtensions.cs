using System.Text;

namespace RGUtility
{
	public static class StringExtensions
	{
		/// <summary>
		/// "ThisIsGreatStuff" => "This Is Great Stuff"
		/// </summary>
		/// <param name="input">the string to convert</param>
		/// <returns>converted string</returns>
		public static string SplitIntoWordsByCase (this string input)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < input.Length; i++)
			{
				if (i > 0 && !char.IsUpper(input[i - 1]) && char.IsUpper(input[i]))
				{
					sb.Append(' ');
				}

				sb.Append(input[i]);
			}

			return sb.ToString();
		}

		/// <summary>
		/// Convert first letter of string to uppercase. (Ignore other letters)
		/// </summary>
		/// <param name="input">the string to convert</param>
		/// <returns>converted string</returns>
		public static string UppercaseFirstLetter (this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}

			return char.ToUpper(input[0]) + input.Substring(1);
		}

		/// <summary>
		/// Convert first letter of string to lowercase. (Ignore other letters)
		/// </summary>
		/// <param name="input">the string to convert</param>
		/// <returns>converted string</returns>
		public static string LowercaseFirstLetter (this string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}

			return char.ToLower(input[0]) + input.Substring(1);
		}
	}
}