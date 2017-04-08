using UnityEngine;

namespace RGUtility
{
	public static class ColorExtensions
	{
		/// <summary>
		/// Returns new Color with new alpha.
		/// </summary>
		/// <returns>The alpha.</returns>
		/// <param name="color">The input color.</param>
		/// <param name="alpha">The passed alpha.</param>
		public static Color SetAlpha (this Color color, float alpha)
		{
			color.a = alpha;
			return color;
		}
	}
}