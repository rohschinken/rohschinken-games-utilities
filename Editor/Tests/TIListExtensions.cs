using System.Collections.Generic;
using NUnit.Framework;
using RGUtility;

namespace UnityTest.Utility
{
	public class TIListExtensions
	{
		public class DummyClass
		{
			public DummyClass ()
			{
			}
		}

		[Test]
		public void RemoveNulls ()
		{
			List<object> list = new List<object> { null, new DummyClass(), "hello", "world", null, null, new DummyClass(), "test", null };

			Assert.That(list.Count == 9);

			list.RemoveNulls();

			Assert.That(list.Count == 5);
			Assert.That(list[0] != null);
			Assert.That((string) list[1] == "hello");
		}
	}
}