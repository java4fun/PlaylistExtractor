using PlaylistExtractor.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PlaylistExtractor.Base
{
    public class YoutubeExtractor : IExtractor
    {
        public YoutubeExtractor()
        {
            ServiceHost = "www.youtube.com";
            ServiceRegex = @"(youtube\.com|youtu\.be)\/playlist\?list=[a-zA-Z0-9]+((-|_)[a-zA-Z0-9]+)?";
        }

        public override IEnumerable<Video> DoExtraction(string url)
        {
            string html = GetHtmlDecoded(url);

            doc.LoadHtml(html);

            var items = Regex.Matches(doc.ParsedText, "data-video-id=\"(?<vidid>.*)\".*?data-title=\"(?<vidtitle>.*)\"");

            var videos = new List<Video>(items.Count);

            if (items.Count > 0)
            {
                foreach (Match item in items)
                {
                    Video video = new Video
                    {
                        Title = item.Groups["vidtitle"].Value,
                        Url = $"www.youtube.com/watch?v={item.Groups["vidid"].Value}"
                    };

                    videos.Add(video);
                }
            }

            return videos;
        }
    }
}
