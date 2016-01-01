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
	public abstract partial class AbstractVideoDisplayer : UserControl
	{
		//=============================================================
		//	Protected constructors
		//=============================================================
		
		protected AbstractVideoDisplayer()
		{
			InitializeComponent();
		}

		//=============================================================
		//	Protected properties
		//=============================================================

		protected AbstractVideo Video
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public void Update(AbstractVideo video)
		{
			Video = video;
			switch (video.Type)
			{
				case AbstractVideo.VideoType.MOVIE: Update(video as Movie);
					break;
				case AbstractVideo.VideoType.SERIES: Update(video as Series);
					break;
			}
			this.Update();
		}

		//=============================================================
		//	Protected methods
		//=============================================================

		protected abstract void Update(Movie movie);

		protected abstract void Update(Series series);
	}
}
