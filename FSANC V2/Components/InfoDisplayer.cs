using SeriesMovieInfoDatabase.Objects;

namespace FSANC_V2.Components
{
	public partial class InfoDisplayer : AbstractVideoDisplayer
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		public InfoDisplayer()
		{
			InitializeComponent();
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override void Update(AbstractVideo video)
		{
			Label_Title.Text = video.Title;
			Label_Year.Text = video.Year == 0 ? "" : video.Year.ToString();
			Label_Genres.Text = Utils.ConcatWithSeparator(video.Genres, Properties.Resources.STR_GENRES_SEPARATOR);

			base.Update(video);
		}

		//-------------------------------------------------------------
		//	Protected methods
		//-------------------------------------------------------------

		protected override void Update(Movie movie)
		{
			Control_SeasonsInfo.Hide();
		}

		protected override void Update(Series series)
		{
			Control_SeasonsInfo.Update(series);
			Control_SeasonsInfo.Show();
		}
	}
}
