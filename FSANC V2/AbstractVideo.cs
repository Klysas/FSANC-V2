using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	public abstract class AbstractVideo
	{
		#region Public enum

		public enum VideoType{
			MOVIE,	
			SERIES
		}

		#endregion

		#region Public properties

		public int Id
		{
			get;
			private set;
		}

		public string Name
		{
			get;
			private set;
		}

		public int Year
		{
			get;
			private set;
		}

		public VideoType Type
		{
			get;
			protected set;
		}

		public string[] Genres
		{
			get;
			set;
		}

		#endregion

		#region Protected constructors

		protected AbstractVideo(int id, string name, int year)
		{
			this.Id = id;
			this.Name = name;
			this.Year = year;
		}

		#endregion

		#region Public methods

		public override string ToString()
		{
			return string.Format("{0}:\t{1}\t\t{2}", this.Type.ToString(), this.Name, this.Year);
		}

		#endregion
	}
}
