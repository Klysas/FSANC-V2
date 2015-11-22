using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FSANC_V2.Components;

namespace FSANC_V2
{
	public partial class InfoDisplayer : AbstractVideoDisplayer
	{

		#region Private variables

		#endregion

		#region Public constructors

		public InfoDisplayer()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		protected override void Update(Movie movie)
		{
			SeasonInfo.Hide();
		}

		protected override void Update(Series series)
		{
			SeasonInfo.Show();
			SeasonInfo.UpdateInfo(series);
		}

		#endregion

		#region Public methods

		public new void Update(AbstractVideo video)
		{
			LblTitle.Text = video.Name;
			LblYear.Text = video.Year == 0 ? "" : video.Year.ToString();
			LblGenres.Text = Utils.ConcatWithSeparator(video.Genres, Properties.Resources.STR_GENRES_SEPARATOR);
			
			base.Update(video);
		}

		#endregion
	}
}
