using System.Text;

namespace RGUtility
{
	public static class Console
	{
		public static string Log (params object[] objects)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < objects.Length; i++)
			{
				sb.Append(objects[i].ToString());
				if (i < objects.Length - 1)
				{
					sb.Append(", ");
				}
			}
			string s = sb.ToString();
			UnityEngine.Debug.Log(s);
			return s;
		}
	}
}