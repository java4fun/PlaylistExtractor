using System.Collections.Generic;

namespace PlaylistExtractor.Models
{
    public class Video
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public IEnumerable<string> DownloadUrls { get; set; }

        public override string ToString()
        {
            return $"{Title}: {Url}";
        }
    }
}
