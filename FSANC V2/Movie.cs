using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	public sealed class Movie : AbstractVideo
	{
		#region Public constructors

		public Movie(int id, string name, int year)
			: base(id, name, year)
		{
			this.Type = VideoType.MOVIE;
		}

		#endregion
	}
}
