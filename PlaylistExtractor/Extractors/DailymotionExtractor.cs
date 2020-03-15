using HtmlAgilityPack;
using PlaylistExtractor.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlaylistExtractor.Base
{
    public class DailymotionExtractor : IExtractor
    {
        public DailymotionExtractor()
        {
            ServiceHost = "www.dailymotion.com";
            ServiceRegex = @"dailymotion\.com\/playlist\/[a-z0-9]+(-)?";
        }

        public override IEnumerable<Video> DoExtraction(string url)
        {
            string html = GetHtmlDecoded(url);

            doc.LoadHtml(html);

            return null; // todo - implement (the videos content aren't static on the html)
        }
    }
}
