using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2
{
	public partial class InfoDisplayer : UserControl
	{

		#region Public constructors

		public InfoDisplayer()
		{
			InitializeComponent();
		}

		#endregion

		#region Public methods

		public void Update(AbstractVideo video)
		{
			LblTitle.Text	= video.Name;
			LblYear.Text	= video.Year == 0 ? "" : video.Year.ToString();
			LblGenres.Text	= Utils.ConcatWithSeparator(video.Genres, Properties.Resources.STR_GENRES_SEPARATOR);

			switch (video.Type)
			{
				case AbstractVideo.VideoType.MOVIE: Update(video as Movie);
					break;
				case AbstractVideo.VideoType.SERIES: Update(video as Series);
					break;
			}
			this.Update();
		}

		#endregion

		#region Private methods

		private void Update(Movie movie)
		{

		}

		private void Update(Series series)
		{

		}

		#endregion
	}
}
