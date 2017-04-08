using System;

namespace RGUtility
{
	public static class EnumExtensions
	{
		/// <summary>
		/// Determines if the enum has a certain flag.
		/// WARNING: use with caution. this might be slow and/or error prone.
		/// </summary>
		/// <returns><c>true</c> if has flag; otherwise, <c>false</c>.</returns>
		/// <param name="input">the enum.</param>
		/// <param name="flag">the flag to find in enum.</param>
		public static bool HasFlag (this Enum input, Enum flag)
		{
			if (input.GetType() != flag.GetType())
			{
				throw new ArgumentException(string.Format("Argument_EnumTypeDoesNotMatch: {0} and {1}", flag.GetType(), input.GetType()));
			}
			return (Convert.ToUInt32(input) & Convert.ToUInt32(flag)) == Convert.ToUInt32(flag);
		}

		/// <summary>
		/// Returns input with passed flag included.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flag">the flag to add.</param>
		public static Enum AddFlag (this Enum input, Enum flag)
		{
			return input.Or(flag);
		}

		/// <summary>
		/// Returns input with passed flags included.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flags">the flags to add.</param>
		public static Enum AddFlags (this Enum input, params Enum[] flags)
		{
			for (int i = 0; i < flags.Length; i++)
			{
				input = input.Or(flags[i]);
			}
			return input;
		}

		/// <summary>
		/// Returns input without passed flag.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flag">the flag to remove.</param>
		public static Enum RemoveFlag (this Enum input, Enum flag)
		{
			if (input.GetType() != flag.GetType())
			{
				throw new ArgumentException(string.Format("Argument_EnumTypeDoesNotMatch: {0} and {1}", input.GetType(), flag.GetType()));
			}

			if (Enum.GetUnderlyingType(input.GetType()) != typeof(ulong))
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToInt64(input) & ~Convert.ToInt64(flag));
			else
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToUInt64(input) & ~Convert.ToUInt64(flag));
		}

		/// <summary>
		/// Returns input without passed flags.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flags">the flags to remove.</param>
		public static Enum RemoveFlags (this Enum input, params Enum[] flags)
		{
			for (int i = 0; i < flags.Length; i++)
			{
				input = input.RemoveFlag(flags[i]);
			}
			return input;
		}

		/// <summary>
		/// Returns input with toggled passed flag.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flag">the flag to toggle.</param>
		public static Enum ToggleFlag (this Enum input, Enum flag)
		{
			if (input.GetType() != flag.GetType())
			{
				throw new ArgumentException(string.Format("Argument_EnumTypeDoesNotMatch: {0} and {1}", input.GetType(), flag.GetType()));
			}

			if (Enum.GetUnderlyingType(input.GetType()) != typeof(ulong))
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToInt64(input) ^ Convert.ToInt64(flag));
			else
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToUInt64(input) ^ Convert.ToUInt64(flag));
		}

		/// <summary>
		/// Returns input with toggled passed flags.
		/// </summary>
		/// <param name="input">the enum.</param>
		/// <param name="flags">the flags to toggle.</param>
		public static Enum ToggleFlags (this Enum input, params Enum[] flags)
		{
			for (int i = 0; i < flags.Length; i++)
			{
				input = input.ToggleFlag(flags[i]);
			}
			return input;
		}

		/// <summary>
		/// Returns input with passed flag included.
		/// </summary>
		/// <param name="input">the original enum.</param>
		/// <param name="flag">the flag to add.</param>
		public static Enum Or (this Enum input, Enum flag)
		{
			if (input.GetType() != flag.GetType())
			{
				throw new ArgumentException(string.Format("Argument_EnumTypeDoesNotMatch: {0} and {1}", input.GetType(), flag.GetType()));
			}

			if (Enum.GetUnderlyingType(input.GetType()) != typeof(ulong))
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToInt64(input) | Convert.ToInt64(flag));
			else
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToUInt64(input) | Convert.ToUInt64(flag));
		}

		/// <summary>
		/// Checks input against the passed flag and returns result.
		/// </summary>
		/// <param name="input">the original enum.</param>
		/// <param name="flag">the flag to check against.</param>
		public static Enum And (this Enum input, Enum flag)
		{
			if (input.GetType() != flag.GetType())
			{
				throw new ArgumentException(string.Format("Argument_EnumTypeDoesNotMatch: {0} and {1}", input.GetType(), flag.GetType()));
			}

			if (Enum.GetUnderlyingType(input.GetType()) != typeof(ulong))
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToInt64(input) & Convert.ToInt64(flag));
			else
				return (Enum) Enum.ToObject(input.GetType(), Convert.ToUInt64(input) & Convert.ToUInt64(flag));
		}

		/// <summary>
		/// Returns inverted enum.
		/// </summary>
		/// <param name="input">the enum.</param>
		public static Enum Not (this Enum input)
		{
			return (Enum) Enum.ToObject(input.GetType(), ~Convert.ToInt64(input));
		}
	}
}