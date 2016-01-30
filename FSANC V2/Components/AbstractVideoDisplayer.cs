using System.Windows.Forms;
using SeriesMovieInfoDatabase.Objects;

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

		public virtual void Update(AbstractVideo video)
		{
			Video = video;
			switch (video.Type)
			{
				case VideoType.Movie: Update(video as Movie);
					break;
				case VideoType.Series: Update(video as Series);
					break;
			}
			Update();
		}

		//-------------------------------------------------------------
		//	Protected methods
		//-------------------------------------------------------------

		protected abstract void Update(Movie movie);

		protected abstract void Update(Series series);
	}
}
