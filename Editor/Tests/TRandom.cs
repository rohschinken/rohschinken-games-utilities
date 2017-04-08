using System.Collections.Generic;
using NUnit.Framework;
using RGUtility;

namespace UnityTest.Utility
{
	public class TRandom
	{
		public enum TRandomEnum
		{
			ONE,
			TWO,
			THREE
		}

		[Test]
		public void Double ()
		{
			for (int i = 0; i < 100000; i++)
			{
				var d = Random.Double();
				Assert.Less(d, 1d);
				Assert.GreaterOrEqual(d, 0d);
			}
		}

		[Test]
		[MaxTime(50)]
		public void DoubleSpeed ()
		{
			for (int i = 0; i < 100000; i++)
			{
				Random.Double();
			}
		}

		[Test]
		public void Float01 ()
		{
			for (int i = 0; i < 100000; i++)
			{
				var f = Random.Float01();
				Assert.Less(f, 1f);
				Assert.GreaterOrEqual(f, 0f);
			}
		}

		[Test]
		[MaxTime(50)]
		public void Float01Speed ()
		{
			for (int i = 0; i < 100000; i++)
			{
				Random.Float01();
			}
		}

		[Test]
		public void Float ()
		{
			for (int i = 0; i < 100000; i++)
			{
				var f = Random.Float(-1.2345f, 1.2345f);
				Assert.Less(f, 1.2345f);
				Assert.GreaterOrEqual(f, -1.2345f);
			}

			for (int i = 0; i < 100000; i++)
			{
				var f = Random.Float(-1f, 1f);
				Assert.Less(f, 1f);
				Assert.GreaterOrEqual(f, -1f);
			}
		}

		[Test]
		[MaxTime(50)]
		public void FloatSpeed ()
		{
			for (int i = 0; i < 100000; i++)
			{
				Random.Float(-1.2345f, 1.2345f);
			}
		}

		[Test]
		public void Integer ()
		{
			for (int j = 0; j < 100000; j++)
			{
				var i = Random.Integer(-12, 12);
				Assert.Less(i, 12f);
				Assert.GreaterOrEqual(i, -12);
			}
		}

		[Test]
		[MaxTime(200)]
		public void IntegerSpeed ()
		{
			for (int j = 0; j < 100000; j++)
			{
				Random.Integer(-12, 12);
			}
		}

		[Test]
		public void Bool ()
		{
			int trueCount = 0;
			int falseCount = 0;
			for (int i = 0; i < 100000; i++)
			{
				if (Random.Bool)
					trueCount++;
				else
					falseCount++;
			}
			Assert.That(trueCount > 0);
			Assert.That(falseCount == (100000 - trueCount));
		}

		[Test]
		[MaxTime(200)]
		public void BoolSpeed ()
		{
			int trueCount = 0;
			int falseCount = 0;
			for (int i = 0; i < 100000; i++)
			{
				if (Random.Bool)
					trueCount++;
				else
					falseCount++;
			}
		}

		[Test]
		public void From ()
		{
			int[] count = { 0, 0, 0 };

			List<TRandomEnum> list = new List<TRandomEnum> {
				TRandomEnum.ONE,
				TRandomEnum.TWO,
				TRandomEnum.THREE
			};

			for (int i = 0; i < 100000; i++)
			{
				switch (Random.From(list))
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}

			Assert.That(count[0] > 0);
			Assert.That(count[1] > 0);
			Assert.That(count[2] == (100000 - (count[0] + count[1])));
		}

		[Test]
		[MaxTime(200)]
		public void FromSpeed ()
		{
			int[] count = { 0, 0, 0 };

			List<TRandomEnum> list = new List<TRandomEnum> {
				TRandomEnum.ONE,
				TRandomEnum.TWO,
				TRandomEnum.THREE
			};

			for (int i = 0; i < 100000; i++)
			{
				switch (Random.From(list))
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}
		}

		[Test]
		public void FromEnum ()
		{
			int[] count = { 0, 0, 0 };

			for (int i = 0; i < 100000; i++)
			{
				switch (Random.FromEnum<TRandomEnum>())
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}

			Assert.That(count[0] > 0);
			Assert.That(count[1] > 0);
			Assert.That(count[2] == (100000 - (count[0] + count[1])));
		}

		[Test]
		[MaxTime(200)]
		public void FromEnumSpeed ()
		{
			int[] count = { 0, 0, 0 };

			for (int i = 0; i < 100000; i++)
			{
				switch (Random.FromEnum<TRandomEnum>())
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}
		}

		[Test]
		public void FromWeightedDistribution ()
		{
			int[] count = { 0, 0, 0 };

			List<KeyValuePair<TRandomEnum, int>> weightedList = new List<KeyValuePair<TRandomEnum, int>>
			{
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.ONE, 1),
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.TWO, 3),
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.THREE, 5)
			};

			for (int i = 0; i < 100; i++)
			{
				switch (Random.FromWeighted(weightedList))
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}

			Assert.That(count[0] < count[1]);
			Assert.That(count[1] < count[2]);
		}

		[Test]
		[MaxTime(200)]
		public void FromWeightedSpeed ()
		{
			int[] count = { 0, 0, 0 };

			List<KeyValuePair<TRandomEnum, int>> weightedList = new List<KeyValuePair<TRandomEnum, int>>
			{
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.ONE, 1),
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.TWO, 3),
				new KeyValuePair<TRandomEnum, int>(TRandomEnum.THREE, 5)
			};

			for (int i = 0; i < 100000; i++)
			{
				switch (Random.FromWeighted(weightedList))
				{
					case TRandomEnum.ONE:
						count[0]++;
						break;

					case TRandomEnum.TWO:
						count[1]++;
						break;

					case TRandomEnum.THREE:
						count[2]++;
						break;
				}
			}
		}
	}
}