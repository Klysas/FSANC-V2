using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	public sealed class Series : AbstractVideo
	{
		#region Private variables

		private Season[] _seasons;

		#endregion

		#region Public properties

		public bool SeasonsLoaded
		{
			get;
			private set;
		}

		public Season[] Seasons
		{
			get
			{
				return _seasons != null ? (Season[])_seasons.Clone() : null;
			}
			set
			{
				if (value != null && !Utils.HasNullItems(value))
				{
					_seasons = value;
					SeasonsLoaded = true;
				}
			}
		}

		#endregion

		#region Public constructors

		public Series(int id, string name, int year)
			: base(id, name, year)
		{
			this.Type = VideoType.SERIES;
		}

		#endregion

		#region Public methods

		#endregion
	}
}
