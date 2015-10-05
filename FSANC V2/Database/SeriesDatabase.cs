using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMDbLib.Objects.General;
using TMDbLib.Objects.Search;

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

		/// <summary>
		/// Finds all series by given name.
		/// </summary>
		/// <param name="name">Name of series.</param>
		/// <returns>List of series.</returns>
		public Series[] FindSeries(string name)
		{
			SearchContainer<SearchTv> container = _client.SearchTvShow(name);

			if (container.Results.Count == 0) return new Series[0];

			Series[] list = new Series[container.Results.Count];
			int i = 0;
			foreach (SearchTv series in container.Results)
			{
				list[i++] = new Series(series.Id, series.Name, Utils.ExtractYear(series.FirstAirDate));
			}
			return list;
		}

		/// <summary>
		/// Updates series's genres.
		/// </summary>
		/// <param name="series"></param>
		/// <returns></returns>
		public Series UpdateGenres(Series series)
		{
			series.Genres = GetGenres(_client.GetTvShow(series.Id));
			return series;
		}

		/// <summary>
		/// Updates seasons and episodes information.
		/// </summary>
		/// <param name="series"></param>
		/// <returns></returns>
		public Series UpdateSeasonsEpisodesInfo(Series series)
		{
			series.Seasons = GetSeasons(_client.GetTvShow(series.Id));
			return series;
		}

		#endregion
	}
}
