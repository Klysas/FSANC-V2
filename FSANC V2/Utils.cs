using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;

namespace FSANC_V2
{
	class Utils
	{
		/// <summary>
		/// Checks if TMDB API key is valid.
		/// </summary>
		/// <param name="key">TMDB API key.</param>
		/// <returns>True if API key is valid, false - otherwise.</returns>
		public static bool IsKeyValid(string key)
		{
			TMDbClient client = new TMDbClient(key);
			try
			{
				client.AuthenticationRequestAutenticationToken();
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Gets year value from date.
		/// </summary>
		/// <param name="date"></param>
		/// <returns>If date is null retruns 0, otherwise - year.</returns>
		public static int ExtractYear(DateTime? date)
		{
			if (date == null) return 0;
			return date.Value.Year;
		}

		/// <summary>
		/// Concatinates given string array and inserts given separator between each element.
		/// </summary>
		/// <param name="array"></param>
		/// <param name="separator"></param>
		/// <returns>Concatinated string array.</returns>
		public static string ConcatWithSeparator(string[] array, string separator)
		{
			if (array == null)
			{
				return string.Empty;
			}
			
			string str = string.Empty;
			if (array.Length > 0)
			{
				str += array[0];

				for (int i = 1; i < array.Length; i++)
				{
					str += separator;
					str += array[i];
				}
			}
			return str;
		}
	}
}
