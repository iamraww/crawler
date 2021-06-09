using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Crawler.Cr
{
    public class DanTriCrawler : Crawler
    {
        public override Article CrawlerHtml()
        {
            List<Article> listArticleDanTri = new List<Article>();
            var url = "https://dantri.com.vn/xa-hoi.htm";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var listNode =
                doc.DocumentNode.SelectNodes(
                    "//div[contains(@class, 'news-item')]/h3[contains(@class,'news-item__title')]/a");
            var image =
                doc.DocumentNode.SelectNodes(
                    "//div[contains(@class, 'news-item')]/a[contains(@class,'news-item__avatar')]/div[contains(@class, 'dt-thumbnail')]/img");
            var content =
                doc.DocumentNode.SelectNodes(
                    "//div[contains(@class, 'news-item')]/div[contains(@class,'news-item__content')]/a");
            var time =
                doc.DocumentNode.SelectNodes(
                    "//div[contains(@class, 'news-item')]/div[contains(@class,'news-item__content')]/div[contains(@class, 'news-item__meta')]/span");
            for (int i = 0; i < time.Count; i++)
            {
                Article articleDanTri = new Article();
                articleDanTri.Url = listNode.ElementAt(i).Attributes["href"].Value;
                articleDanTri.Title = listNode.ElementAt(i).InnerText;
                articleDanTri.Images = image.ElementAt(i).Attributes["src"].Value;
                articleDanTri.Content = content.ElementAt(i).InnerText;
                articleDanTri.Time = time.ElementAt(i).InnerText;
                listArticleDanTri.Add(articleDanTri);
            }

            for (int j = 0; j < listArticleDanTri.Count; j++)
            {
                Console.WriteLine($"Bài viết {j + 1}");
                Console.WriteLine($"Url: dantri.com.vn{listArticleDanTri[j].Url}");
                Console.WriteLine($"Title: {listArticleDanTri[j].Title}");
                Console.WriteLine($"Image: {listArticleDanTri[j].Images}");
                Console.WriteLine($"Content: {listArticleDanTri[j].Content}");
                Console.WriteLine($"Update At: {listArticleDanTri[j].Time}");
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------");
            }

            return null;
        }
    }
}