using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;

namespace FSANC_V2
{
	partial class Database
	{
		#region Private methods

		/// <summary>
		/// Converts Genre list to string array.
		/// </summary>
		/// <param name="list"></param>
		/// <returns>Genres in string array.</returns>
		private string[] GetGenres(List<Genre> list)
		{
			string[] genres = new string[list.Count];
			int i = 0;
			foreach (Genre genre in list)
			{
				genres[i++] = genre.Name;// TODO: "Science Fiction" change to "Sci-Fi"
			}
			return genres;
		}

		#endregion
	}
}
