using System;

namespace SeriesMovieInfoDatabase.Objects
{
	public sealed class Season
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private Episode[] _episodes;

		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates object of this class with given parameters.
		/// </summary>
		/// <param name="seasonNumber"></param>
		/// <param name="episodes"></param>
		/// <exception cref="System.ArgumentException">Thrown when episodes contains null item(s).</exception>
		public Season(int seasonNumber, Episode[] episodes)
		{
			if (Utils.HasNullItems(episodes))
			{
				throw new ArgumentException("episodes contains null elements(s).", "episodes");
			}
			this.Number = seasonNumber;
			this._episodes = episodes == null ? new Episode[0] : episodes;
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] Episodes array.
		/// </summary>
		public Episode[] Episodes
		{
			get
			{
				return (Episode[])_episodes.Clone();
			}
		}

		/// <summary>
		/// [GET] Episodes count.
		/// </summary>
		public int EpisodesCount
		{
			get
			{
				return _episodes.Length;
			}
		}

		/// <summary>
		/// [GET] Season number.
		/// </summary>
		public int Number
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return string.Format("Season: {0}, episodes count: {1}.", Number, EpisodesCount);
		}
	}
}
