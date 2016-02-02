using SeriesMovieInfoDatabase.Objects;
using TMDbLib.Objects.Search;
using TMDbLib.Objects.TvShows;

namespace SeriesMovieInfoDatabase
{
	public sealed partial class Database
	{
		//=============================================================
		//	Private methods
		//=============================================================

		private Series GetSeries(SearchTv series)
		{
			var tempSeries = _client.GetTvShow(series.Id);

			var sTitle = series.Name;
			var sYear = ExtractYear(series.FirstAirDate);
			var sGenres = GenresToArray(tempSeries.Genres);
			var sSeasons = GetSeasons(tempSeries);

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

				string sName = episode.Name ?? "Unknown";

				episodeList[i] = new Episode(sName, episode.EpisodeNumber, season.SeasonNumber);
			}

			return episodeList;
		}
	}
}
