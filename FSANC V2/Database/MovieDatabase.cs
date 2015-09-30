using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	partial class Database
	{
		#region Private methods

		private string[] GetGenres(TMDbLib.Objects.Movies.Movie movie)
		{
			return GetGenres(movie.Genres);
		}

		#endregion

		#region Public methods

		#endregion
	}
}
