using System.Collections.Generic;
using System.Linq;
using PlaylistExtractor.Models;
using HtmlAgilityPack;
using PlaylistExtractor.Contracts;

namespace PlaylistExtractor.Base
{
    internal class VimeoExtractor : Extractor
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
                    Url = $"www.vimeo.com/{video.GetAttributeValue("href", string.Empty).Split('/').Last()}"
                };
            }
        }
    }
}
