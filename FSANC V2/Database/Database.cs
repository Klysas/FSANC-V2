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
		/// Updates video's genres.
		/// </summary>
		/// <param name="video"></param>
		/// <returns></returns>
		public AbstractVideo UpdateGenres(AbstractVideo video)
		{
			if (video.Type == AbstractVideo.VideoType.MOVIE)
			{
				return UpdateGenres(video as Movie);
			}
			else
			{
				return UpdateGenres(video as Series);
			}
		}

		#endregion
	}
}
