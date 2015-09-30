using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	public sealed class Episode
	{
		#region Public properties

		public int SeasonNumber
		{
			get;
			private set;
		}

		public int EpisodeNumber
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		#endregion
		
		#region Public constructor

		public Episode(int season, int episode, string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("Episode name is null.");
			}

			this.SeasonNumber = season;
			this.EpisodeNumber = episode;
			this.Name = name;
		}

		#endregion

		#region Public methods

		public override string ToString()
		{
			return string.Format("Season: {0}, episode: {1}, title: {2}.", SeasonNumber, EpisodeNumber, Name);
		}

		#endregion
	}
}
