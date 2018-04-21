using HtmlAgilityPack;
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

            foreach(Match video in videos)
            {
                yield return new Video
                {
                    Title = video.Groups[2].Value,
                    Url = $"www.youtube.com/watch?v={video.Groups[1].Value}"
                };
            }
        }
    }
}
