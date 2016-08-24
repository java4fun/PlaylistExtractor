using System.Collections.Generic;
using System.Linq;
using PlaylistExtractor.Models;
using HtmlAgilityPack;
using PlaylistExtractor.Contracts;

namespace PlaylistExtractor.Base
{
    internal class VimeoExtractor : Extractor
    {
        private const string _urlPattern = @"vimeo\.com\/groups\/[a-z0-9]+";

        public override string UrlPattern { get { return _urlPattern; } }

        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            if (!TryLoadHtmlFromUrl(url)) yield break;

            var videos = htmlDocument.DocumentNode.SelectNodes("//*[@id='browse_content']/ol/li/a");

            if (videos == null) yield break;

            foreach (HtmlNode video in videos)
            {
                yield return new Video
                {
                    Title = video.GetAttributeValue("title", string.Empty),
                    Url = $"www.vimeo.com/{video.GetAttributeValue("href", string.Empty).Split('/').Last()}"
                };
            }
        }
    }
}
