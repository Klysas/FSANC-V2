using System;
using System.Linq;
using TMDbLib.Client;
using SeriesMovieInfoDatabase.Objects;
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
		private readonly TMDbClient _client;

		/// <summary>
		/// Holds search progress data.
		/// </summary>
		private readonly SearchProgress _progress;

		/// <summary>
		/// Belongs to ReturnedResultsCount property.
		/// </summary>
		private int _returnedResultsCount;

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

			// Initialization.
			_client = new TMDbClient(key);
			_progress = new SearchProgress();
			_seriesProgress = new SearchProgress();

			// Setting up current state.
			CurrentState = State.Idle;
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
		/// [GET] Contains current <see cref="State">state</see> of database.
		/// </summary>
		public State CurrentState
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET/SET] Count of search results returned.
		/// <p/>Default value is 20. To return all results set to 0. Range 0..infinity.
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
		/// NOTE: Database runs one search at a time. If search is running and 
		/// you call Find method - it will return empty results array(won't start second search).
		/// To start new search, you have to Stop search(CurrentState == Idle).
		/// </summary>
		/// <param name="title">Title of series or movie.</param>
		/// <returns>Array of found series and movies.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public AbstractVideo[] FindSeriesAndMovies(string title)
		{
			if (CurrentState != State.Idle) return new AbstractVideo[0];
			try
			{
				CurrentState = State.Running;
				Validate(title);

				var movieContainer = _client.SearchMovie(title);
				var seriesContainer = _client.SearchTvShow(title);

				if (movieContainer.Results.Count == 0 && seriesContainer.Results.Count == 0) return new AbstractVideo[0];

				int moviesCount, seriesCount;
				if (ReturnedResultsCount == 0)
				{
					// Return all results.
					moviesCount = movieContainer.TotalResults;
					seriesCount = seriesContainer.TotalResults;
				}
				else
				{
					moviesCount = seriesCount = ReturnedResultsCount / 2;
				}

				_progress.CurrentItemsCount = 0;
				_progress.TotalItemsCount = moviesCount;
				_progress.TotalItemsCount += (seriesCount * PROGRESS_POINTS_PER_SERIES);

				var movies = FindMovies(title, moviesCount);
				var series = FindSeries(title, seriesCount);
				return movies.Union<AbstractVideo>(series).ToArray();
			}
			catch (CancelledException)
			{
				return new AbstractVideo[0];
			}
			finally
			{
				CurrentState = State.Idle;
			}
		}

		/// <summary>
		/// Finds movies by given title.
		/// NOTE: Database runs one search at a time. If search is running and 
		/// you call Find method - it will return empty results array(won't start second search).
		/// To start new search, you have to Stop search(CurrentState == Idle).
		/// </summary>
		/// <param name="title">Title of movie.</param>
		/// <returns>Array of found movies.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public Movie[] FindMovies(string title)
		{
			if (CurrentState != State.Idle) return new Movie[0];
			try
			{
				CurrentState = State.Running;
				Validate(title);
				var container = _client.SearchMovie(title);

				if (container.Results.Count == 0) return new Movie[0];

				_progress.CurrentItemsCount = 0;
				_progress.TotalItemsCount = (ReturnedResultsCount == 0) || (ReturnedResultsCount > container.TotalResults)
					? container.TotalResults : ReturnedResultsCount;

				return FindMovies(title, _progress.TotalItemsCount);
			}
			catch (CancelledException)
			{
				return new Movie[0];
			}
			finally
			{
				CurrentState = State.Idle;
			}
		}

		/// <summary>
		/// Finds series by given title.
		/// NOTE: Database runs one search at a time. If search is running and 
		/// you call Find method - it will return empty results array(won't start second search).
		/// To start new search, you have to Stop search(CurrentState == Idle).
		/// </summary>
		/// <param name="title">Title of series.</param>
		/// <returns>Array of found series.</returns>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public Series[] FindSeries(string title)
		{
			if (CurrentState != State.Idle) return new Series[0];
			try
			{
				CurrentState = State.Running;
				Validate(title);
				var container = _client.SearchTvShow(title);

				if (container.Results.Count == 0) return new Series[0];

				_progress.CurrentItemsCount = 0;
				_progress.TotalItemsCount = ((ReturnedResultsCount == 0) || (ReturnedResultsCount > container.TotalResults)
					? container.TotalResults : ReturnedResultsCount) * PROGRESS_POINTS_PER_SERIES;

				return FindSeries(title, _progress.TotalItemsCount);
			}
			catch (CancelledException)
			{
				return new Series[0];
			}
			finally
			{
				CurrentState = State.Idle;
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
			if (CurrentState == State.Running)
			{
				CurrentState = State.Stopping;
			}
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		private Movie[] FindMovies(string title, int totalResults)
		{
			var movies = new Movie[totalResults];

			int pageIndex = 1;
			int movieIndex = 0;
			do
			{
				var container = _client.SearchMovie(title, pageIndex);

				foreach (SearchMovie movie in container.Results)
				{
					movies[movieIndex++] = OnNewVideo(GetMovie(movie));
					if (movieIndex >= totalResults) break;
				}
				pageIndex++;
			} while (movieIndex < totalResults);

			return movies;
		}

		private Series[] FindSeries(string title, int totalResults)
		{
			var seriesArray = new Series[totalResults];

			int pageIndex = 1;
			int seriesIndex = 0;
			do
			{
				var container = _client.SearchTvShow(title, pageIndex);

				foreach (SearchTv series in container.Results)
				{
					seriesArray[seriesIndex++] = OnNewVideo(GetSeries(series));
					if (seriesIndex >= totalResults) break;
				}
				pageIndex++;
			} while (seriesIndex < totalResults);

			return seriesArray;
		}

		private Series OnNewVideo(Series series)
		{
			_progress.CurrentItemsCount += PROGRESS_POINTS_PER_SERIES;
			OnNewVideo((AbstractVideo)series);
			return series;
		}

		private Movie OnNewVideo(Movie movie)
		{
			_progress.CurrentItemsCount++;
			OnNewVideo((AbstractVideo)movie);
			return movie;
		}

		private void OnNewVideo(AbstractVideo video)
		{
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
			var handler = VideoFound;
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
		private static void Validate(string title)
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
		//	Private classes
		//=============================================================

		private class SearchProgress
		{
			public SearchProgress()
			{
				CurrentItemsCount = 0;
				TotalItemsCount = 0;
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

		private class CancelledException : Exception
		{
			// Default constructor is enough.
		}
	}

	//=============================================================
	//	Public EventArgs classes
	//=============================================================

	public class SearchProgressEventArgs : EventArgs
	{
		/// <summary>
		/// Creates object of this class using current and total values. Calculates percentage value of given two values.
		/// Should be (current < total).
		/// </summary>
		/// <param name="current"></param>
		/// <param name="total"></param>
		public SearchProgressEventArgs(int current, int total)
		{
			CurrentItemsCount = current;
			TotalItemsCount = total;
			ProgressInPercents = 100 * current / total;
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
		/// [GET] Progress in percentages(0..100). Calculated from TotalItemsCount and CurrentItemsCount.
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
			Video = video;
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
}
