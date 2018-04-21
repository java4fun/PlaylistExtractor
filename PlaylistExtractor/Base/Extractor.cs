using PlaylistExtractor.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace PlaylistExtractor.Base
{
    internal abstract class Extractor : IExtractor
    {
        protected readonly HtmlAgilityPack.HtmlDocument htmlDocument;

        public Extractor()
        {
            htmlDocument = new HtmlAgilityPack.HtmlDocument();
        }

        public abstract IEnumerable<IVideo> DoExtraction(string url);

        private string GetHtmlDecoded(string address)
        {
            using (var client = new WebClient())
            {
                try
                {
                    return HttpUtility.HtmlDecode(client.DownloadString(address));
                }
                catch
                {
                    return null;
                }
            }
        }

        protected void LoadHtmlFromUrl(string url)
        {
            htmlDocument.LoadHtml(GetHtmlDecoded(url));
        }
    }
}
