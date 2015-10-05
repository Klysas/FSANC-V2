using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

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

		/// <summary>
		/// Finds all movies by given name.
		/// </summary>
		/// <param name="name">Name of movie.</param>
		/// <returns>List of movies.</returns>
		public Movie[] FindMovies(string name)
		{
			SearchContainer<SearchMovie> container = _client.SearchMovie(name);

			if (container.Results.Count == 0) return new Movie[0];

			Movie[] list = new Movie[container.Results.Count];
			int i = 0;
			foreach (SearchMovie movie in container.Results)
			{
				list[i++] = new Movie(movie.Id, movie.Title, Utils.ExtractYear(movie.ReleaseDate));
			}
			return list;
		}

		/// <summary>
		/// Updates movie's genres.
		/// </summary>
		/// <param name="movie"></param>
		/// <returns></returns>
		public Movie UpdateGenres(Movie movie)
		{
			movie.Genres = GetGenres(_client.GetMovie(movie.Id));
			return movie;
		}

		#endregion
	}
}
