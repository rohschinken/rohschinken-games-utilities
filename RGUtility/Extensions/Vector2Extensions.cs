using UnityEngine;

namespace RGUtility
{
	public static class Vector2Extensions
	{
		/// <summary>
		/// Return the Vector with X field adjusted. Use like this: "vec = vec.SetX(x);"
		/// </summary>
		/// <param name="vector">the Vector2</param>
		/// <param name="x">the x</param>
		/// <returns></returns>
		public static Vector2 SetX (this Vector2 vector, float x)
		{
			vector.x = x;
			return vector;
		}

		/// <summary>
		/// Return the Vector with Y field adjusted. Use like this: "vec = vec.SetY(y);"
		/// </summary>
		/// <param name="vector">the Vector2</param>
		/// <param name="y">the y</param>
		/// <returns></returns>
		public static Vector2 SetY (this Vector2 vector, float y)
		{
			vector.y = y;
			return vector;
		}
	}
}