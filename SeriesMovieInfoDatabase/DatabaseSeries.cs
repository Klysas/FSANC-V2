using SeriesMovieInfoDatabase.Objects;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace SeriesMovieInfoDatabase
{
	public sealed partial class Database
	{
		//-------------------------------------------------------------
		//	Private variables
		//-------------------------------------------------------------

		private const int PROGRESS_POINTS_PER_SERIES = 50;

		/// <summary>
		/// Used to tract progress of individual series.
		/// </summary>
		private readonly SearchProgress _seriesProgress;

		//=============================================================
		//	Private methods
		//=============================================================

		private Series GetSeries(SearchTv series)
		{
			var tempSeries = _client.GetTvShow(series.Id);

			// Reset progress for series.
			_seriesProgress.CurrentItemsCount = 0;
			_seriesProgress.TotalItemsCount = tempSeries.NumberOfEpisodes;

			var sTitle = series.Name;
			var sYear = ExtractYear(series.FirstAirDate);
			var sGenres = GenresToArray(tempSeries.Genres);
			var sSeasons = GetSeasons(tempSeries);

			ThrowIfCancelled();

			return new Series(sTitle, sYear, sGenres, sSeasons);
		}

		private Season[] GetSeasons(TvShow show)
		{
			if (show.NumberOfSeasons == 0) return new Season[0];

			var seasons = new Season[show.NumberOfSeasons];

			int index = show.NumberOfSeasons != show.Seasons.Count ? 1 : 0;
			for (int i = index; i < show.Seasons.Count; i++)
			{
				var currentSeason = show.Seasons[i];
				seasons[currentSeason.SeasonNumber - 1] = new Season(currentSeason.SeasonNumber, GetEpisodes(show.Id, currentSeason));
			}

			return seasons;
		}

		private Episode[] GetEpisodes(int tvShowId, TvSeason season)
		{
			if (season.EpisodeCount == 0) return new Episode[0];

			var episodeList = new Episode[season.EpisodeCount];
			for (int i = 0; i < season.EpisodeCount; i++)
			{
				var episode = _client.GetTvEpisode(tvShowId, season.SeasonNumber, i + 1);

				ThrowIfCancelled();

				string sName = episode.Name ?? "Unknown";
				if (sName.Equals("")) sName = "Unknown";

				episodeList[i] = new Episode(sName, episode.EpisodeNumber, season.SeasonNumber);

				_seriesProgress.CurrentItemsCount++;
				ReportSeriesProgress();
			}

			return episodeList;
		}

		/// <summary>
		/// Triggers ProgressChanged event.
		/// </summary>
		private void ReportSeriesProgress()
		{
			var pointsCompleted = _seriesProgress.CurrentItemsCount * PROGRESS_POINTS_PER_SERIES / _seriesProgress.TotalItemsCount; // FIX: TotalItemsCount can be zero(protect).
			OnSearchProgressChanged(new SearchProgressEventArgs(_progress.CurrentItemsCount + pointsCompleted, _progress.TotalItemsCount));
		}
	}
}
