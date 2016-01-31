using System.Linq;

namespace FSANC_V2
{
	public static class Utils
	{
		//=============================================================
		//	Public static methods
		//=============================================================

		/// <summary>
		/// Concatenates given string array and inserts given separator between each element.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="separator"></param>
		/// <returns>Concatenated string array.</returns>
		public static string ConcatWithSeparator(string[] array, string separator)
		{
			if (array == null)
			{
				return string.Empty;
			}

			var str = string.Empty;
			if (array.Length <= 0) return str;

			str += array[0];
			for (var i = 1; i < array.Length; i++)
			{
				str += separator;
				str += array[i];
			}
			return str;
		}

		/// <summary>
		/// Checks if array has null items.
		/// </summary>
		/// <param name="array">Can be NULL.</param>
		/// <returns>True if array contains null, otherwise false(if array = null, false too).</returns>
		public static bool HasNullItems(object[] array)
		{
			return array != null && array.Any(item => item == null);
		}
	}
}
