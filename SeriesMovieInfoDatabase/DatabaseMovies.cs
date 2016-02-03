using SeriesMovieInfoDatabase.Objects;
using TMDbLib.Objects.Search;

namespace SeriesMovieInfoDatabase
{
	public sealed partial class Database
	{
		//=============================================================
		//	Private methods
		//=============================================================

		private Movie GetMovie(SearchMovie movie)
		{
			var tempMovie = _client.GetMovie(movie.Id);

			var mTitle = movie.Title;
			var mYear = ExtractYear(movie.ReleaseDate);
			var mGenres = GenresToArray(tempMovie.Genres);

			ThrowIfCancelled();

			return new Movie(mTitle, mYear, mGenres);
		}
	}
}
