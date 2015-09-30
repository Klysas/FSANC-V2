using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	class Season
	{
		#region Private variables

		private Episode[] _episodes;

		#endregion

		#region Public properties

		/// <summary>
		/// Season number.
		/// </summary>
		public int Number
		{
			get;
			private set;
		}

		/// <summary>
		/// Count of episodes season has.
		/// </summary>
		public int EpisodeCount
		{
			get
			{
				return _episodes.Length;
			}
		}

		/// <summary>
		/// Array of episodes.
		/// </summary>
		public Episode[] Episodes
		{
			get
			{
				return (Episode[])_episodes.Clone();
			}
		}

		#endregion
		
		#region Public constructors

		public Season(int season, Episode[] episodes)
		{
			if (episodes == null)
			{
				throw new ArgumentNullException("Episodes array is null.");
			}
			if (episodes.Length == 0)
			{
				throw new ArgumentException("Episodes array is empty.");
			}
			if (Utils.HasNullItems(episodes))
			{
				throw new ArgumentException("Episodes array contains null item(s).");
			}

			this.Number = season;

			// Make sure that array index == episodeNumber.
			this._episodes = new Episode[episodes.Length];
			foreach (Episode item in episodes)
			{
				_episodes[item.EpisodeNumber - 1] = item;
			}
		}

		#endregion

		#region Public methods

		public Episode getEpisode(int number)
		{
			return _episodes[number - 1];
		}

		public override string ToString()
		{
			return string.Format("Season: {0}, episodes count: {1}.", Number, EpisodeCount);
		}

		#endregion
	}
}
