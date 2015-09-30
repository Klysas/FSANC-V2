using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	class Series : AbstractVideo
	{
		#region Private variables



		#endregion

		#region Public properties

		public Season[] Seasons
		{
			get;
			set;
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
