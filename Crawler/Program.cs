using System;
using System.Collections.Generic;
using System.Text;
using Crawler.Cr;
using Crawler.crawler;

namespace Crawler
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            CrawlerVnexpress crawlerVnexpress = new CrawlerVnexpress();
            CrawlerDantri crawlerDantri = new CrawlerDantri();
            // List<string> listUrl = crawlerVnexpress.CrawUrl("https://vnexpress.net/the-thao");
            // for (int i = 0; i < listUrl.Count; i++)
            // {
            //     Console.WriteLine(listUrl[i]);
            //     // Article article = crawlerVnexpress.CrawDetail(listUrl[i]);
            //     // Console.WriteLine(article.ToShortString());
            // }
            
            List<string> listUrl = crawlerDantri.CrawUrl("https://dantri.com.vn/");
            for (int i = 0; i < listUrl.Count; i++)
            {
                Console.WriteLine(listUrl[i]);
                Article article = crawlerDantri.CrawDetail(listUrl[i]);
                Console.WriteLine(article.ToShortString());
            }
        }
    }
}