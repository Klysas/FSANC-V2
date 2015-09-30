using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSANC_V2
{
	partial class Database
	{
		#region Private methods

		private Season[] GetSeasons(TMDbLib.Objects.TvShows.TvShow show)
		{
			// First season(array index = 0) contains special episodes.
			var seasons = new Season[show.Seasons.Count - 1];
			for (int i = 0; i < show.Seasons.Count - 1; i++)
			{
				var currentSeason = show.Seasons[i + 1];
				seasons[i] = new Season(currentSeason.SeasonNumber, GetEpisodes(show.Id, currentSeason));
			}
			return seasons;
		}

		private Episode[] GetEpisodes(int tvShowId, TMDbLib.Objects.TvShows.TvSeason season)
		{
			var episodeList = new Episode[season.EpisodeCount];
			for (int j = 0; j < season.EpisodeCount; j++)
			{
				var episode = _client.GetTvEpisode(tvShowId, season.SeasonNumber, j + 1);
				episodeList[j] = new Episode(season.SeasonNumber, episode.EpisodeNumber, episode.Name);
			}
			return episodeList;
		}

		private string[] GetGenres(TMDbLib.Objects.TvShows.TvShow show)
		{
			return GetGenres(show.Genres);
		}

		#endregion

		#region Public methods

		public Series UpdateSeasonsEpisodesInfo(Series series)
		{
			series.Seasons = GetSeasons(_client.GetTvShow(series.Id));
			return series;
		}

		#endregion
	}
}
