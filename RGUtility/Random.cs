using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RGUtility
{
	public static class Random
	{
		public static readonly System.Random random;

		static Random ()
		{
#if UNITY_EDITOR
			random = new System.Random(4784455);
#else
			random = new System.Random();
#endif
		}

		public static bool Bool
		{
			get
			{
				return Double() >= 0.5d;
			}
		}

		/// <summary>
		/// Random Double between 0.0 (incl.) and 1.0 (excl.)
		/// </summary>
		public static double Double ()
		{
			return random.NextDouble();
		}

		/// <summary>
		/// Random Float between 0.0 (incl.) and 1.0 (excl.)
		/// </summary>
		public static float Float01 ()
		{
			return (float) Double();
		}

		/// <summary>
		/// Random Float between minVal (incl.) and maxVal (excl.)
		/// </summary>
		public static float Float (float minVal = float.MinValue, float maxVal = float.MaxValue)
		{
			if (minVal > maxVal)
			{
				throw new ArgumentException(String.Format("Argument_MinValueTooBig: min {0} must not be bigger than max {1}", minVal, maxVal));
			}

			// Perform arithmetic in double type to avoid overflowing
			double range = (double) maxVal - (double) minVal;
			double sample = Double();
			double scaled = (sample * range) + minVal;
			return (float) scaled;
		}

		/// <summary>
		/// Random Integer between minVal (incl.) and maxVal (excl.)
		/// </summary>
		public static int Integer (int minVal = int.MinValue, int maxVal = int.MaxValue)
		{
			if (minVal > maxVal)
			{
				throw new ArgumentException(String.Format("Argument_MinValueTooBig: min {0} must not be bigger than max {1}", minVal, maxVal));
			}
			return random.Next(minVal, maxVal);
		}

		public static T From<T> (ICollection<T> collection)
		{
			var length = collection.Count;
			var index = Integer(0, length);

			// its safe to use Linq here as .ElementAt() will fall back to indexer if the collection can be casted to IList
			return collection.ElementAt(index);
		}

		public static T FromWeighted<T> (List<KeyValuePair<T, float>> list)
		{
			float totalWeight = 0;
			for (int i = 0; i < list.Count; i++)
			{
				totalWeight += list[i].Value;
			}

			float randWeight = Float(0, totalWeight);

			for (int i = 0; i < list.Count; i++)
			{
				if (randWeight < list[i].Value)
				{
					return list[i].Key;
				}
				randWeight -= list[i].Value;
			}

			throw new NotImplementedException("cannot handle null case");
		}

		public static T FromWeightedNullable<T> (List<KeyValuePair<T, float>> list) where T : class
		{
			float totalWeight = 0;
			for (int i = 0; i < list.Count; i++)
			{
				totalWeight += list[i].Value;
			}

			float randWeight = Float(0, totalWeight);

			for (int i = 0; i < list.Count; i++)
			{
				if (randWeight < list[i].Value)
				{
					return list[i].Key;
				}
				randWeight -= list[i].Value;
			}

			return null;
		}

		public static T FromWeighted<T> (List<KeyValuePair<T, int>> list)
		{
			int totalWeight = 0;
			for (int i = 0; i < list.Count; i++)
			{
				totalWeight += list[i].Value;
			}

			int randWeight = Integer(0, totalWeight);

			for (int i = 0; i < list.Count; i++)
			{
				if (randWeight < list[i].Value)
				{
					return list[i].Key;
				}
				randWeight -= list[i].Value;
			}

			throw new NotImplementedException("cannot handle null case");
		}

		public static T FromWeightedNullable<T> (List<KeyValuePair<T, int>> list) where T : class
		{
			int totalWeight = 0;
			for (int i = 0; i < list.Count; i++)
			{
				totalWeight += list[i].Value;
			}

			int randWeight = Integer(0, totalWeight);

			for (int i = 0; i < list.Count; i++)
			{
				if (randWeight < list[i].Value)
				{
					return list[i].Key;
				}
				randWeight -= list[i].Value;
			}

			return null;
		}

		public static T FromEnum<T> () where T : struct, IConvertible
		{
			var values = Enum.GetValues(typeof(T));

			var index = Integer(0, values.Length);
			return (T) values.GetValue(index);
		}

		public static List<KeyValuePair<int, float>> GetWeightedListFromMinMaxCurve (int min, int max, AnimationCurve curve)
		{
			List<KeyValuePair<int, float>> weightList = new List<KeyValuePair<int, float>>();

			float totalRange = (max - min) * 1f;
			for (int i = min; i < max; i++)
			{
				weightList.Add(new KeyValuePair<int, float>(i, curve.Evaluate(((i - min) * 1f) / (totalRange * 1f))));
			}

			return weightList;
		}
	}
}