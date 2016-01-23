
namespace SeriesMovieInfoDatabase.Objects
{
	public sealed class Movie : AbstractVideo
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates instance of this class with given parameters.
		/// </summary>
		/// <param name="title">Movie title.</param>
		/// <param name="year">Year of release.</param>
		/// <param name="genres">Array of Movie genres.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when:
		/// Genres contains null element(s).
		/// Title is empty.</exception>
		public Movie(string title, int year, string[] genres)
			: base(title, year, genres)
		{
			this.Type = VideoType.Movie;
		}
	}
}
