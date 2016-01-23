using System;

namespace SeriesMovieInfoDatabase.Objects
{
	public sealed class Episode
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates instance of Episode by given arguments.
		/// </summary>
		/// <param name="title"></param>
		/// <param name="episodeNumber"></param>
		/// <param name="seasonNumber"></param>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when title is empty.</exception>
		public Episode(string title, int episodeNumber, int seasonNumber)
		{
			if (title == null)
			{
				throw new ArgumentNullException("title");
			}
			if (title.Equals(string.Empty))
			{
				throw new ArgumentException("Title can't be empty.", "title");
			}
			this.Title = title;
			this.Number = episodeNumber;
			this.SeasonNumber = seasonNumber;
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] Episode number.
		/// </summary>
		public int Number
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET] Season number.
		/// </summary>
		public int SeasonNumber
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET] Episode title.
		/// </summary>
		public string Title
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return string.Format("Season: {0}, episode: {1}, title: {2}.", SeasonNumber, Number, Title);
		}
	}
}
