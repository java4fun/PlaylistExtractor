using PlaylistExtractor.Contracts;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace PlaylistExtractor.Base
{
    internal abstract class Extractor : IExtractor
    {
        protected readonly HtmlAgilityPack.HtmlDocument htmlDocument;

        public abstract string UrlPattern { get; }

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

        protected bool TryLoadHtmlFromUrl(string url)
        {
            var html = GetHtmlDecoded(url);

            if (string.IsNullOrEmpty(html)) return false;

            htmlDocument.LoadHtml(html);

            return true;
        }
    }
}
