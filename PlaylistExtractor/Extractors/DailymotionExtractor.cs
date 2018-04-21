using System.Collections.Generic;
using PlaylistExtractor.Models;
using HtmlAgilityPack;
using PlaylistExtractor.Contracts;

namespace PlaylistExtractor.Base
{
    internal class DailymotionExtractor : Extractor
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
                    Title = video.GetAttributeValue("title", string.Empty),
                    Url = $"www.dailymotion.com{video.GetAttributeValue("href", string.Empty)}"
                };
            }
        }
    }
}
