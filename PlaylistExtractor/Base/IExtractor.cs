using HtmlAgilityPack;
using PlaylistExtractor.Models;
using System.Collections.Generic;
using System.Net;
using System.Web;

namespace PlaylistExtractor.Base
{
    public abstract class IExtractor
    {
        public string ServiceHost { get; protected set; }
        public string ServiceRegex { get; protected set; }


        protected readonly HtmlDocument doc;

        public IExtractor()
        {
            doc = new HtmlDocument();
        }

        public abstract IEnumerable<Video> DoExtraction(string url);

        protected string GetHtmlDecoded(string address)
        {
            using (var client = new WebClient())
            {
                try
                {
                    string html = client.DownloadString(address);
                    return HttpUtility.HtmlDecode(html);
                }
                catch
                {
                    return "";
                }
            }
        }
    }
}
