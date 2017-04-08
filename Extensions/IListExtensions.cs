using System.Collections.Generic;

namespace RGUtility
{
	public static class IListExtensions
	{
		/// <summary>
		/// Removes null entries from IList.
		/// </summary>
		/// <param name="collection">the collection.</param>
		/// <typeparam name="T">T must be of type class.</typeparam>
		public static void RemoveNulls<T> (this IList<T> collection) where T : class
		{
			for (var i = collection.Count - 1; i >= 0; i--)
			{
				if (collection[i] == null)
					collection.RemoveAt(i);
			}
		}
	}
}