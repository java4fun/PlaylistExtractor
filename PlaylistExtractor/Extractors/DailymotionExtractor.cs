using System.Collections.Generic;
using PlaylistExtractor.Models;
using HtmlAgilityPack;
using PlaylistExtractor.Contracts;

namespace PlaylistExtractor.Base
{
    internal class DailymotionExtractor : Extractor
    {
        private const string _urlPattern = @"dailymotion\.com\/playlist\/[a-z0-9]+(-)?";
        
        public override string UrlPattern { get { return _urlPattern; } }

        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            if (!TryLoadHtmlFromUrl(url)) yield break;

            var videos = htmlDocument.DocumentNode.SelectNodes("//*[@id='content']/div[1]/div/div[2]/div[1]/div[3]/div/div/div/div/h3/a");

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
