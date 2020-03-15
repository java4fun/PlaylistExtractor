using PlaylistExtractor.Models;
using System.Collections.Generic;

namespace PlaylistExtractor.Base
{
    public class VimeoExtractor : IExtractor
    {
        public VimeoExtractor()
        {
            ServiceHost = "www.vimeo.com";
            ServiceRegex = @"vimeo\.com\/album\/[a-z0-9]+";
        }

        public override IEnumerable<Video> DoExtraction(string url)
        {
            string html = GetHtmlDecoded(url);

            doc.LoadHtml(html);

            return null; // TO DO - Implement extractor.
        }
    }
}
