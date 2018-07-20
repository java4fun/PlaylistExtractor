using PlaylistExtractor.Contracts;
using PlaylistExtractor.Base;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Threading.Tasks;

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
                    @"vimeo\.com\/album\/[a-z0-9]+",
                    new VimeoExtractor()
                },
                {
                    @"dailymotion\.com\/playlist\/[a-z0-9]+(-)?",
                    new DailymotionExtractor()
                }
            };
        }

        public Task<IEnumerable<IVideo>> ExtractVideosAsync(string playlistUrl)
        {
            return Task.Factory.StartNew(() => TryGetExtractor(playlistUrl)?.DoExtraction(playlistUrl));
        }

        private IExtractor TryGetExtractor(string url)
        {
            return _extractors.SingleOrDefault(e => Regex.IsMatch(url, e.Key)).Value;
        }
    }
}
