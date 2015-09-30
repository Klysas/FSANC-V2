using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2.Components
{
	public partial class TorrentDisplayer : AbstractVideoDisplayer
	{
		#region Public constructors

		public TorrentDisplayer()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		protected override void Update(Movie movie)
		{

		}

		protected override void Update(Series series)
		{

		}

		#endregion

		#region Public methods

		public new void Update(AbstractVideo video)
		{
			LblTitle.Text = video.Name;

			base.Update(video);
		}

		#endregion
	}
}
