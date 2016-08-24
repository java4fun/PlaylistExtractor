using System.Collections.Generic;

namespace PlaylistExtractor.Contracts
{
    public interface IVideo
    {
        string Title { get; set; }
        string Url { get; set; }
        IEnumerable<string> DownloadUrls { get; set; }
        string ToString();
    }
}
