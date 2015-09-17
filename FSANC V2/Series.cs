using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	class Series : AbstractVideo
	{
		#region Public constructors

		public Series(int id, string name, int year)
			: base(id, name, year)
		{
			this.Type = VideoType.SERIES;
		}

		#endregion
	}
}
