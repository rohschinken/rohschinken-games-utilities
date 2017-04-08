using NUnit.Framework;
using RGUtility;

namespace UnityTest.Utility
{
	public class TEnumExtensions
	{
		[System.Flags]
		public enum TTestFlags
		{
			undefined = 0,
			ONE = (1 << 0),
			TWO = (1 << 1),
			THREE = (1 << 2)
		}

		[Test]
		public void AddSingleFlag ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.AddFlags(TTestFlags.ONE);
			Assert.That(flags == TTestFlags.ONE);
		}

		[Test]
		public void HasSingleFlag ()
		{
			TTestFlags flags = TTestFlags.ONE;
			Assert.That(flags.HasFlag(TTestFlags.ONE));
		}

		[Test]
		public void AddMultipleFlags ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.AddFlags(TTestFlags.ONE, TTestFlags.TWO);
			flags = (TTestFlags) flags.AddFlags(TTestFlags.THREE);
			Assert.That(flags.HasFlag(TTestFlags.ONE));
			Assert.That(flags.HasFlag(TTestFlags.TWO));
			Assert.That(flags.HasFlag(TTestFlags.THREE));
		}

		[Test]
		public void RemoveSingleFlag ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.AddFlags(TTestFlags.ONE, TTestFlags.TWO);
			flags = (TTestFlags) flags.RemoveFlag(TTestFlags.ONE);
			Assert.That(flags.HasFlag(TTestFlags.ONE) == false);
			Assert.That(flags.HasFlag(TTestFlags.TWO));
		}

		[Test]
		public void RemoveMultipleFlags ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.AddFlags(TTestFlags.ONE, TTestFlags.TWO, TTestFlags.THREE);
			flags = (TTestFlags) flags.RemoveFlags(TTestFlags.ONE, TTestFlags.TWO);
			Assert.That(flags.HasFlag(TTestFlags.ONE) == false);
			Assert.That(flags.HasFlag(TTestFlags.TWO) == false);
			Assert.That(flags.HasFlag(TTestFlags.THREE));
		}

		[Test]
		public void ToggleSingleFlag ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.ToggleFlag(TTestFlags.ONE);
			Assert.That(flags.HasFlag(TTestFlags.ONE));
			flags = (TTestFlags) flags.ToggleFlag(TTestFlags.ONE);
			Assert.That(flags.HasFlag(TTestFlags.ONE) == false);
		}

		[Test]
		public void ToggleMultipleFlags ()
		{
			TTestFlags flags = TTestFlags.undefined;
			flags = (TTestFlags) flags.ToggleFlags(TTestFlags.ONE, TTestFlags.TWO);
			Assert.That(flags.HasFlag(TTestFlags.ONE));
			Assert.That(flags.HasFlag(TTestFlags.TWO));
			flags = (TTestFlags) flags.ToggleFlags(TTestFlags.ONE);
			Assert.That(flags.HasFlag(TTestFlags.ONE) == false);
			Assert.That(flags.HasFlag(TTestFlags.TWO));
			flags = (TTestFlags) flags.ToggleFlags(TTestFlags.ONE, TTestFlags.TWO);
			Assert.That(flags.HasFlag(TTestFlags.ONE));
			Assert.That(flags.HasFlag(TTestFlags.TWO) == false);
		}
	}
}