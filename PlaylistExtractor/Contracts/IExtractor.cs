using System.Collections.Generic;

namespace PlaylistExtractor.Contracts
{
    internal interface IExtractor
    {
        string UrlPattern { get; }
        IEnumerable<IVideo> DoExtraction(string url);
    }
}
