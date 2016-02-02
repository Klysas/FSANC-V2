using System;

namespace SeriesMovieInfoDatabase.Objects
{
	public enum VideoType
	{
		Movie,
		Series
	}

	public abstract class AbstractVideo
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly string[] _genres;

		//=============================================================
		//	Protected constructors
		//=============================================================

		/// <summary>
		/// 
		/// </summary>
		/// <param name="title"></param>
		/// <param name="year"></param>
		/// <param name="genres">Array of genres.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when:
		/// Genres contains null element(s).
		/// Title is empty. </exception>
		protected AbstractVideo(string title, int year, string[] genres)
		{
			if (title == null)
			{
				throw new ArgumentNullException("title");
			}
			if (title.Equals(string.Empty))
			{
				throw new ArgumentException("Title can't be empty.", "title");
			}
			if (Utils.HasNullItems(genres))
			{
				throw new ArgumentException("Genres array contains null element(s).", "genres");
			}
			Title = title;
			Year = year;
			_genres = genres ?? new string[0];
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] Genres array.
		/// </summary>
		public string[] Genres
		{
			get
			{
				return (string[])_genres.Clone();
			}
		}

		/// <summary>
		/// [GET] Title.
		/// </summary>
		public string Title
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET] Video type.
		/// </summary>
		public VideoType Type
		{
			get;
			protected set;
		}

		/// <summary>
		/// [GET] Year.
		/// </summary>
		public int Year
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return string.Format("{0}: \t{1}\t\t {2}", Type.ToString(), Title, Year);
		}
	}
}
