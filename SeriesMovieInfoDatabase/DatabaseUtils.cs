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
			if (string.IsNullOrEmpty(key)) return false;
			try
			{
				var client = new TMDbClient(key);
				client.AuthenticationRequestAutenticationToken();
				return true;
			}
			catch (UnauthorizedAccessException)
			{
				return false;
			}
		}

		//-------------------------------------------------------------
		//	Private static methods
		//-------------------------------------------------------------

		/// <summary>
		/// Gets year value from date.
		/// </summary>
		/// <param name="date"></param>
		/// <returns>If date is null returns 0, otherwise - year.</returns>
		private static int ExtractYear(DateTime? date)
		{
			return date == null ? 0 : date.Value.Year;
		}

		/// <summary>
		/// Converts Genre list to string array.
		/// </summary>
		/// <param name="list">Genres list.</param>
		/// <returns>Genres in string array.</returns>
		private static string[] GenresToArray(IReadOnlyCollection<Genre> list)
		{
			if (list == null || list.Count == 0) return new string[0];

			var array = new string[list.Count];
			int i = 0;
			foreach (var genre in list)
			{
				array[i++] = genre.Name.Equals("Science Fiction") ? "Sci-Fi" : genre.Name;
			}
			return array;
		}

		//-------------------------------------------------------------
		//	Private non-static methods
		//-------------------------------------------------------------

		/// <summary>
		/// Exception is thrown if CurrentState == Stopping.
		/// </summary>
		/// <exception cref="CancelledException"></exception>
		private void ThrowIfCancelled()
		{
			if (CurrentState == State.Stopping)
			{
				throw new CancelledException();
			}
		}
	}
}
