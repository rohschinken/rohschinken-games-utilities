using UnityEngine;

namespace RGUtility
{
	public static class LinearAlgebra
	{
		/// <summary>
		/// Get a random position on a circles edge.
		/// </summary>
		/// <returns>The circle.</returns>
		/// <param name="center">The circles center.</param>
		/// <param name="radius">The circles radius.</param>
		/// <param name="maxAngle">The max angle of our random position.</param>
		public static Vector3 RandomPositionOnCircle (Vector3 center, float radius, float maxAngle = 360f)
		{
			float angle = Random.Float01() * Mathf.Clamp(maxAngle, 0f, 360f);
			return new Vector3(
				center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad),
				center.y + radius * Mathf.Cos(angle * Mathf.Deg2Rad),
				center.z
			);
		}
	}
}