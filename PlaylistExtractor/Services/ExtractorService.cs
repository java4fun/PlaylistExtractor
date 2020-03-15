using PlaylistExtractor.Base;
using PlaylistExtractor.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaylistExtractor.Services
{
    public class ExtractorService
    {
        private readonly Dictionary<string, IExtractor> services;

        public ExtractorService()
        {
            IExtractor[] svcArr =
            {
                new YoutubeExtractor()
            };

            services = new Dictionary<string, IExtractor>();

            foreach (IExtractor svc in svcArr)
            {
                services.Add(svc.ServiceHost, svc);
            }
        }

        public async Task<IEnumerable<Video>> ExtractVideosAsync(string listUrl)
        {
            bool success = TryGetExtractor(listUrl, out IExtractor extractor);

            if (success)
            {
                return await Task.Run(() =>
                {
                    return extractor.DoExtraction(listUrl);
                });
            }
            else
            {
                return null;
            }
        }

        private bool TryGetExtractor(string url, out IExtractor extractor)
        {
            string host = new Uri(url).Host;
            return services.TryGetValue(host, out extractor);
        }
    }
}
