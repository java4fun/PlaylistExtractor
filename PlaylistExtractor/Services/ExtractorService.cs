using PlaylistExtractor.Contracts;
using PlaylistExtractor.Base;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PlaylistExtractor.Services
{
    public class ExtractorService
    {
        private readonly IDictionary<string, IExtractor> _extractors;

        private static readonly ExtractorService _instance = new ExtractorService();

        public static ExtractorService GetInstance()
        {
            return _instance;
        }

        private ExtractorService()
        {
            _extractors = new Dictionary<string, IExtractor>
            {
                { "youtube.com", new YoutubeExtractor() },
                { "vimeo.com", new VimeoExtractor() },
                { "dailymotion.com", new DailymotionExtractor() }
            };
        }

        public IEnumerable<IVideo> ExtractVideos(string playlistUrl)
        {
            return TryGetExtractor(playlistUrl)?.DoExtraction(playlistUrl);
        }

        private IExtractor TryGetExtractor(string url)
        {
            var host = new Uri(url).Host.Replace("www.", string.Empty);

            if (!_extractors.ContainsKey(host)) return null;

            var extractor = _extractors[host];
            
            return Regex.IsMatch(url, extractor.UrlPattern) ? extractor : null;
        }
    }
}
