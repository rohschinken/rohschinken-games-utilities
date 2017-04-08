using UnityEngine;

namespace RGUtility
{
	public static class Vector3Extensions
	{
		/// <summary>
		/// Return the Vector with X field adjusted. Use like this: "vec = vec.SetX(x);"
		/// </summary>
		/// <param name="vector">the Vector3</param>
		/// <param name="x">the x</param>
		/// <returns></returns>
		public static Vector3 SetX (this Vector3 vector, float x)
		{
			vector.x = x;
			return vector;
		}

		/// <summary>
		/// Return the Vector with Y field adjusted. Use like this: "vec = vec.SetY(y);"
		/// </summary>
		/// <param name="vector">the Vector3</param>
		/// <param name="y">the y</param>
		/// <returns></returns>
		public static Vector3 SetY (this Vector3 vector, float y)
		{
			vector.y = y;
			return vector;
		}

		/// <summary>
		/// Return the Vector with Z field adjusted. Use like this: "vec = vec.SetY(z);"
		/// </summary>
		/// <param name="vector">the Vector3</param>
		/// <param name="z">the z</param>
		/// <returns></returns>
		public static Vector3 SetZ (this Vector3 vector, float z)
		{
			vector.z = z;
			return vector;
		}
	}
}