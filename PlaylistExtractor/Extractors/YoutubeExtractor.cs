using HtmlAgilityPack;
using PlaylistExtractor.Contracts;
using PlaylistExtractor.Models;
using System.Collections.Generic;

namespace PlaylistExtractor.Base
{
    internal class YoutubeExtractor : Extractor
    {
        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            LoadHtmlFromUrl(url);

            var videos = htmlDocument.DocumentNode.SelectNodes("ADD XPATH HERE");

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
