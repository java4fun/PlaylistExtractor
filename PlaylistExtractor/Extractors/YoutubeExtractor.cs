using PlaylistExtractor.Contracts;
using PlaylistExtractor.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PlaylistExtractor.Base
{
    internal class YoutubeExtractor : Extractor
    {
        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            LoadHtmlFromUrl(url);

            string html = htmlDocument.ParsedText;

            var videos = Regex.Matches(html, "data-video-id=\"(.*?)\".*?data-title=\"(.*?)\"");

            var ret = new List<IVideo>(videos.Count);

            foreach(Match video in videos)
            {
                ret.Add(new Video
                {
                    Title = video.Groups[2].Value,
                    Url = $"www.youtube.com/watch?v={video.Groups[1].Value}"
                });
            }

            return ret;
        }
    }
}
