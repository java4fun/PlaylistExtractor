using HtmlAgilityPack;
using PlaylistExtractor.Contracts;
using PlaylistExtractor.Models;
using System.Collections.Generic;

namespace PlaylistExtractor.Base
{
    internal class YoutubeExtractor : Extractor
    {
        private const string _urlPattern = @"(youtube\.com|youtu\.be)\/playlist\?list=[a-zA-Z0-9]+((-|_)[a-zA-Z0-9]+)?";

        public override string UrlPattern { get { return _urlPattern; } }

        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            if (!TryLoadHtmlFromUrl(url)) yield break;

            var videos = htmlDocument.DocumentNode.SelectNodes("//*[@id='pl-video-table']/tbody/tr");

            if (videos == null) yield break;

            foreach (HtmlNode video in videos)
            {
                yield return new Video
                {
                    Title = video.GetAttributeValue("data-title", string.Empty),
                    Url = $"www.youtube.com/watch?v={video.GetAttributeValue("data-video-id", string.Empty)}"
                };
            }
        }
    }
}
