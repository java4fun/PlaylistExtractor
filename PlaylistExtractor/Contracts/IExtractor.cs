using System.Collections.Generic;

namespace PlaylistExtractor.Contracts
{
    internal interface IExtractor
    {
        IEnumerable<IVideo> DoExtraction(string url);
    }
}
