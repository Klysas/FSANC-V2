using System;
using System.Collections.Generic;
using TMDbLib.Client;
using TMDbLib.Objects.General;

namespace SeriesMovieInfoDatabase
{
	public sealed partial class Database
	{
		//=============================================================
		//	Public static methods
		//=============================================================

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

		//=============================================================
		//	Private methods
		//=============================================================

		/// <summary>
		/// Gets year value from date.
		/// </summary>
		/// <param name="date"></param>
		/// <returns>If date is null returns 0, otherwise - year.</returns>
		private int ExtractYear(DateTime? date)
		{
			return date == null ? 0 : date.Value.Year;
		}

		/// <summary>
		/// Converts Genre list to string array.
		/// </summary>
		/// <param name="list">Genres list.</param>
		/// <returns>Genres in string array.</returns>
		private string[] GenresToArray(List<Genre> list)
		{
			// CHECK: What if list is null, how to handle.
			string[] array = new string[list.Count];
			int i = 0;
			foreach (Genre genre in list)
			{
				array[i++] = genre.Name.Equals("Science Fiction") ? "Sci-Fi" : genre.Name;
			}
			return array;
		}
	}
}
