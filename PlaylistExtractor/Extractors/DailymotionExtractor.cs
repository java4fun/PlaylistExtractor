﻿using System.Collections.Generic;
using PlaylistExtractor.Models;
using HtmlAgilityPack;
using PlaylistExtractor.Contracts;

namespace PlaylistExtractor.Base
{
    internal class DailymotionExtractor : Extractor
    {
        public override IEnumerable<IVideo> DoExtraction(string url)
        {
            LoadHtmlFromUrl(url);

            string html = htmlDocument.ParsedText;

            return null; // TO DO - Implement extractor.
        }
    }
}
