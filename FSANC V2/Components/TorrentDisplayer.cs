using SeriesMovieInfoDatabase.Objects;

namespace FSANC_V2.Components
{
	public partial class TorrentDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		public TorrentDisplayer()
		{
			InitializeComponent();
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override void Update(AbstractVideo video)
		{
			Label_Title.Text = video.Title;

			base.Update(video);
		}

		//-------------------------------------------------------------
		//	Protected methods
		//-------------------------------------------------------------

		protected override void Update(Movie movie)
		{

		}

		protected override void Update(Series series)
		{

		}
	}
}
