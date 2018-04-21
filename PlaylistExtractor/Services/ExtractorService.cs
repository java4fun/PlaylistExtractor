using PlaylistExtractor.Contracts;
using PlaylistExtractor.Base;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

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
                {
                    @"(youtube\.com|youtu\.be)\/playlist\?list=[a-zA-Z0-9]+((-|_)[a-zA-Z0-9]+)?",
                    new YoutubeExtractor()
                },
                {
                    @"vimeo\.com\/groups\/[a-z0-9]+",
                    new VimeoExtractor()
                },
                {
                    @"dailymotion\.com\/playlist\/[a-z0-9]+(-)?",
                    new DailymotionExtractor()
                }
            };
        }

        public IEnumerable<IVideo> ExtractVideos(string playlistUrl)
        {
            return TryGetExtractor(playlistUrl)?.DoExtraction(playlistUrl);
        }

        private IExtractor TryGetExtractor(string url)
        {
            var extractor = (from ex in _extractors
                            where Regex.IsMatch(url, ex.Key)
                            select ex.Value).FirstOrDefault();

            return extractor;
        }
    }
}
