using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Client;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace FSANC_V2
{
	partial class Database
	{
		#region Singleton

		private static Database _instance;

		public static Database Instance {
			get 
			{
				if (_instance == null)
					_instance = new Database(Properties.Settings.Default.API_KEY);
				return _instance;
			}
		}

		#endregion

		#region Private variables

		private TMDbClient _client;

		#endregion

		#region Private constructors

		private Database(string key)
		{
			_client = new TMDbClient(key);
		}

		#endregion

		#region Private methods

		private AbstractVideo UpdateInfo(AbstractVideo video)
		{
			if (video.Type == AbstractVideo.VideoType.MOVIE)
			{
				return UpdateInfo(video as Movie);
			}
			else
			{
				return UpdateInfo(video as Series);
			}
		}

		private Movie UpdateInfo(Movie movie)
		{
			TMDbLib.Objects.Movies.Movie theMovie = _client.GetMovie(movie.Id);

			if (theMovie.Id != 0)// If movie was found.
			{
				movie.Genres = GetGenres(theMovie);
			}
			return movie;
		}

		private Series UpdateInfo(Series series)
		{
			TMDbLib.Objects.TvShows.TvShow show = _client.GetTvShow(series.Id);

			// Do I need to check?
			//if (show.Id != 0)// If tvShow was found.
			//{
			//}
			series.Genres = GetGenres(show);

			return series;
		}

		#endregion

		#region Public methods

		/// <summary>
		/// Finds movies and series by given name.
		/// </summary>
		/// <param name="name">Name of video.</param>
		/// <returns>List of movies and series.</returns>
		public AbstractVideo[] FindMoviesAndSeries(string name)
		{
			AbstractVideo[] movies = FindMovies(name);
			AbstractVideo[] series = FindSeries(name);			
			return movies.Union(series).ToArray();
		}

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
				list[i++] = UpdateInfo(new Movie(movie.Id, movie.Title, Utils.ExtractYear(movie.ReleaseDate)));
			}
			return list;
		}

		/// <summary>
		/// Finds all series by given name.
		/// </summary>
		/// <param name="name">Name of series.</param>
		/// <returns>List of series.</returns>
		public Series[] FindSeries(string name)
		{
			SearchContainer<SearchTv> container = _client.SearchTvShow(name);
			
			if (container.Results.Count == 0) return new Series[0];

			Series[] list = new Series[container.Results.Count];
			int i = 0;
			foreach (SearchTv series in container.Results)
			{
				list[i++] = UpdateInfo(new Series(series.Id, series.Name, Utils.ExtractYear(series.FirstAirDate)));
			}
			return list;
		}

		#endregion
	}
}
