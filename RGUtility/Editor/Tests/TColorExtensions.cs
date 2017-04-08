using NUnit.Framework;
using RGUtility;
using UnityEngine;

namespace UnityTest.Utility
{
	public class TColorExtensions
	{
		[Test]
		public void SetAlpha ()
		{
			Color c = new Color(255f, 128f, 0f);
			c = c.SetAlpha(0.5f);
			Assert.AreEqual(c.r, 255f);
			Assert.AreEqual(c.g, 128f);
			Assert.AreEqual(c.b, 0f);
			Assert.AreEqual(c.a, 0.5f);
		}
	}
}