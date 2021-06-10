using System.Collections.Generic;

namespace Crawler.crawler
{
    public interface ICrawler
    {
        Article CrawDetail(string url);
        List<string> CrawUrl(string url);
    }
}