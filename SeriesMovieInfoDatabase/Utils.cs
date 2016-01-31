using System.Linq;

namespace SeriesMovieInfoDatabase
{
	internal static class Utils
	{
		//=============================================================
		//	Public static methods
		//=============================================================

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
