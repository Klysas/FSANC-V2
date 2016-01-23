using System;
using TMDbLib.Client;
using SeriesMovieInfoDatabase.Objects;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

namespace SeriesMovieInfoDatabase
{
	public sealed partial class Database
	{
		//=============================================================
		//	Private variables
		//=============================================================

		/// <summary>
		/// Object to access TMDB framework.
		/// </summary>
		private TMDbClient _client;

		/// <summary>
		/// Belongs to ReturnedResultsCount property.
		/// </summary>
		private int _returnedResultsCount;

		/// <summary>
		/// Holds search progress data.
		/// </summary>
		private SearchProgress _progress;

		/// <summary>
		/// States.
		/// </summary>
		private bool _running;
		private bool _cancelled;

		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates instance of this class.
		/// </summary>
		/// <param name="key">TMDB API key.</param>
		/// <exception cref="System.ArgumentException">Thrown when provided key is invalid.</exception>
		public Database(string key)
		{
			if (!IsKeyValid(key))
			{
				throw new ArgumentException("Invalid key.", "key");
			}
			_client = new TMDbClient(key);
			_progress = new SearchProgress();
			_running = false;
			_cancelled = false;
			Reset();
		}

		//=============================================================
		//	Public events
		//=============================================================

		/// <summary>
		/// This event is triggered when some progress is made in search.
		/// </summary>
		public event EventHandler<SearchProgressEventArgs> SearchProgressChanged;

		/// <summary>
		/// This event is triggered when one <see cref="AbstractVideo">AbstractVideo</see>> is found.
		/// </summary>
		public event EventHandler<VideoFoundEventArgs> VideoFound;

		//=============================================================
		//	Public enums
		//=============================================================

		public enum State
		{
			Idle,
			Running,
			Stopping
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET/SET] Count of search results returned.
		/// <p>Default value is 20. To return all results set to 0. Range 0..infinity.
		/// </summary>
		public int ReturnedResultsCount
		{
			get
			{
				return _returnedResultsCount;
			}
			set
			{
				if (value > -1)
				{
					_returnedResultsCount = value;
				}
			}
		}

		//=============================================================
		//	Public methods
		//=============================================================

		/// <summary>
		/// Finds movies and series by given title.
		/// </summary>
		/// <param name="title">Title of series or movie.</param>
		/// <returns>Array of found series and movies.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public AbstractVideo[] FindSeriesAndMovies(string title)
		{
			throw new NotImplementedException("Use FindSeries() or FindMovies() instead.");

			//Validate(title);

			//SearchContainer<SearchMovie> movieContainer = _client.SearchMovie(title);
			//SearchContainer<SearchTv> seriesContainer = _client.SearchTvShow(title);

			//int moviesCount, seriesCount;
			//if (ReturnedResultsCount == 0) {
			//	// Return all results.
			//	moviesCount = movieContainer.TotalResults;
			//	seriesCount = seriesContainer.TotalResults;
			//}
			//else
			//{
			//	moviesCount = seriesCount = ReturnedResultsCount;
			//}

			//_progress.CurrentItemsCount = 0;
			//_progress.TotalItemsCount = moviesCount;
			//_progress.TotalItemsCount += seriesCount;

			//AbstractVideo[] movies = FindMovies(title, moviesCount);
			//AbstractVideo[] series = FindSeries(title, seriesCount);
			//return movies.Union(series).ToArray();
		}

		/// <summary>
		/// Finds movies by given title.
		/// </summary>
		/// <param name="title">Title of movie.</param>
		/// <returns>Array of found movies.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public Movie[] FindMovies(string title)
		{
			if (_running) Stop();
			try
			{
				_running = true;
				Validate(title);
				SearchContainer<SearchMovie> container = _client.SearchMovie(title);

				if (container.Results.Count == 0) return new Movie[0];

				_progress.CurrentItemsCount = 0;
				_progress.TotalItemsCount = (ReturnedResultsCount == 0) || (ReturnedResultsCount > container.TotalResults) ? container.TotalResults : ReturnedResultsCount;

				return FindMovies(title, _progress.TotalItemsCount);
			}
			finally
			{
				_running = false;
			}
		}

		/// <summary>
		/// Finds series by given title.
		/// </summary>
		/// <param name="title">Title of series.</param>
		/// <returns>Array of found series.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public Series[] FindSeries(string title)
		{
			if (_running) Stop();
			try
			{
				_running = true;
				Validate(title);
				SearchContainer<SearchTv> container = _client.SearchTvShow(title);

				if (container.Results.Count == 0) return new Series[0];

				_progress.CurrentItemsCount = 0;
				_progress.TotalItemsCount = (ReturnedResultsCount == 0) || (ReturnedResultsCount > container.TotalResults) ? container.TotalResults : ReturnedResultsCount;

				return FindSeries(title, _progress.TotalItemsCount);
			}
			finally
			{
				_running = false;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns>Current database state.</returns>
		public State GetState()
		{
			if (!_running)
			{
				return State.Idle;
			}
			else if (!_cancelled)
			{
				return State.Running;
			}
			else
			{
				return State.Stopping;
			}
		}

		/// <summary>
		/// Resets all values to default.
		/// </summary>
		public void Reset()
		{
			ReturnedResultsCount = 20;
		}

		/// <summary>
		/// Stops current search.
		/// </summary>
		public void Stop()
		{
			if (_running)
			{
				_cancelled = true;
				while (_running) { }
				_cancelled = false;
			}
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		private Movie[] FindMovies(string title, int totalResults)
		{
			Movie[] movies = new Movie[totalResults];

			int pageIndex = 1;
			int movieIndex = 0;
			do
			{
				var container = _client.SearchMovie(title, pageIndex);

				foreach (SearchMovie movie in container.Results)
				{
					movies[movieIndex++] = OnNewVideo(GetMovie(movie));
					if (movieIndex >= totalResults) break;
					if (_cancelled) break;
				}
				if (_cancelled) break;
				pageIndex++;
			} while (movieIndex < totalResults);

			return movies;
		}

		private Series[] FindSeries(string title, int totalResults)
		{
			Series[] seriesArray = new Series[totalResults];

			int pageIndex = 1;
			int seriesIndex = 0;
			do
			{
				var container = _client.SearchTvShow(title, pageIndex);

				foreach (SearchTv series in container.Results)
				{
					seriesArray[seriesIndex++] = OnNewVideo(GetSeries(series));
					if (seriesIndex >= totalResults) break;
					if (_cancelled) break;
				}
				if (_cancelled) break;
				pageIndex++;
			} while (seriesIndex < totalResults);

			return seriesArray;
		}

		private Series OnNewVideo(Series series)
		{
			OnNewVideo((AbstractVideo)series);
			return series;
		}

		private Movie OnNewVideo(Movie movie)
		{
			OnNewVideo((AbstractVideo)movie);
			return movie;
		}

		private void OnNewVideo(AbstractVideo video)
		{
			_progress.CurrentItemsCount++;
			OnVideoFound(new VideoFoundEventArgs(video));
			OnSearchProgressChanged(new SearchProgressEventArgs(_progress.CurrentItemsCount, _progress.TotalItemsCount));
		}

		/// <summary>
		/// Triggers SearchProgressChanged event.
		/// </summary>
		/// <param name="e"></param>
		private void OnSearchProgressChanged(SearchProgressEventArgs e)
		{
			EventHandler<SearchProgressEventArgs> handler = SearchProgressChanged;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		/// Triggers VideoFound event.
		/// </summary>
		/// <param name="e"></param>
		private void OnVideoFound(VideoFoundEventArgs e)
		{
			EventHandler<VideoFoundEventArgs> handler = VideoFound;
			if (handler != null)
			{
				handler(this, e);
			}
		}

		/// <summary>
		/// Validates title value.
		/// </summary>
		/// <param name="title">Title of series or movie.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		private void Validate(string title)
		{
			if (title == null)
			{
				throw new ArgumentNullException("title");
			}
			if (title.Equals(string.Empty))
			{
				throw new ArgumentException("Title can't be empty.", "title");
			}
		}

		//=============================================================
		//	Public classes
		//=============================================================

		public class SearchProgressEventArgs : EventArgs
		{
			/// <summary>
			/// Creates object of this class using current and total values. Calcualtes percentage value of given two values.
			/// Should be (current < total).
			/// </summary>
			/// <param name="current"></param>
			/// <param name="total"></param>
			public SearchProgressEventArgs(int current, int total)
			{
				this.CurrentItemsCount = current;
				this.TotalItemsCount = total;
				this.ProgressInPercents = 100 * current / total;
			}

			/// <summary>
			/// [GET]
			/// </summary>
			public int CurrentItemsCount
			{
				get;
				private set;
			}

			/// <summary>
			/// [GET]
			/// </summary>
			public int TotalItemsCount
			{
				get;
				private set;
			}

			/// <summary>
			/// [GET] Progress in percents(0..100). Calculated from TotalItemsCount and CurrentItemsCount.
			/// </summary>
			public int ProgressInPercents
			{
				get;
				private set;
			}
		}

		public class VideoFoundEventArgs : EventArgs
		{
			/// <summary>
			/// Constructs event args with AbstractVideo object.
			/// </summary>
			/// <param name="video"></param>
			public VideoFoundEventArgs(AbstractVideo video)
			{
				this.Video = video;
			}

			/// <summary>
			/// [GET] <see cref="AbstractVideo">AbstractVideo</see> object.
			/// </summary>
			public AbstractVideo Video
			{
				get;
				private set;
			}
		}

		//-------------------------------------------------------------
		//	Private classes
		//-------------------------------------------------------------

		private class SearchProgress
		{
			public SearchProgress()
			{
				this.CurrentItemsCount = 0;
				this.TotalItemsCount = 0;
			}

			public int CurrentItemsCount
			{
				get;
				set;
			}

			public int TotalItemsCount
			{
				get;
				set;
			}
		}
	}
}
