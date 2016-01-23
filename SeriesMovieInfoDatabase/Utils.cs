using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesMovieInfoDatabase
{
	internal sealed class Utils
	{
		//=============================================================
		//	Public static methods
		//=============================================================
		
		/// <summary>
		/// Checks if array has null items.
		/// </summary>
		/// <param name="array">Can be NULL.</param>
		/// <returns>True if array contains null, otherwise false(if array = null, false too).</returns>
		public static bool HasNullItems(Object[] array)
		{
			if (array == null) return false;
			foreach (Object item in array)
			{
				if (item == null) return true;
			}
			return false;
		}
	}
}
