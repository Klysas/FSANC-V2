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

			#region Refactor
			// TODO: refactor.
			int index = 0;
			if (show.Seasons[0].SeasonNumber != 1)
			{
				index++;
			}

			for (int i = index; i < show.Seasons.Count; i++)
			{
				var currentSeason = show.Seasons[i];
				seasons[currentSeason.SeasonNumber - 1] = new Season(currentSeason.SeasonNumber, GetEpisodes(show.Id, currentSeason));
			}
			#endregion

			// Ensures no null in array.
			for (int i = 0; i < seasons.Length; i++)
			{
				if (seasons[i] == null)
				{
					seasons[i] = new Season(i + 1, null);
				}
			}
			return seasons;
		}

		private Episode[] GetEpisodes(int tvShowId, TvSeason season)
		{
			var episodeList = new Episode[season.EpisodeCount];
			for (int i = 0; i < season.EpisodeCount; i++)
			{
				var episode = _client.GetTvEpisode(tvShowId, season.SeasonNumber, i + 1);

				string sName = episode.Name == null ? "Unknown" : episode.Name;

				episodeList[i] = new Episode(sName, episode.EpisodeNumber, season.SeasonNumber);
			}
			return episodeList;
		}
	}
}
