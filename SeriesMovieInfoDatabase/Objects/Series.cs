using System;

namespace SeriesMovieInfoDatabase.Objects
{
	public sealed class Series : AbstractVideo
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private Season[] _seasons;

		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates instance of this class with given parameters.
		/// </summary>
		/// <param name="title">Series title.</param>
		/// <param name="year">Year of release.</param>
		/// <param name="genres">Series genres.</param>
		/// <param name="seasons">Series seasons.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when title is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when:
		/// Genres or seasons contains null element(s).
		/// Title is empty.</exception>
		public Series(string title, int year, string[] genres, Season[] seasons)
			: this(title, year, genres)
		{
			if (Utils.HasNullItems(seasons))
			{
				throw new ArgumentException("seasons contains null element(s).", "seasons");
			}
			if (seasons != null)
			{
				this._seasons = seasons;
			}
		}

		/// <summary>
		/// Creates instance of this class with given parameters.
		/// </summary>
		/// <param name="title">Series title.</param>
		/// <param name="year">Year of release.</param>
		/// <param name="genres">Series genres.</param>
		/// <exception cref="System.ArgumentNullException">Thrown when title or genres is null.</exception>
		/// <exception cref="System.ArgumentException">Thrown when genres contains null element(s)</exception>
		public Series(string title, int year, string[] genres)
			: base(title, year, genres)
		{
			this.Type = VideoType.Series;
			this._seasons = new Season[0]; // Empty array.
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] Seasons array.
		/// </summary>
		public Season[] Seasons
		{
			get
			{
				return (Season[])_seasons.Clone();
			}
		}

		/// <summary>
		/// [GET] Seasons count.
		/// </summary>
		public int SeasonsCount
		{
			get
			{
				return _seasons.Length;
			}
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return string.Format("{0}, seasons count: {1}", base.ToString(), SeasonsCount);
		}
	}
}
