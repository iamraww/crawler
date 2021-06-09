using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Crawler.Cr
{
    public class VnexpressCrawler: Crawler
    {
        public override Article CrawlerHtml()
        {
            List<Article> listArticleVnex = new List<Article>();
            var url = "https://vnexpress.net/giai-tri";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var listNode =
                doc.DocumentNode.SelectNodes(
                    "//article[contains(@class, 'item-news')]/h3[contains(@class,'title-news')]/a");
            var image =
                doc.DocumentNode.SelectNodes(
                    "//article[contains(@class, 'item-news')]/div[contains(@class,'thumb-art')]/a[contains(@class, 'thumb')]/picture/img");
            var content =
                doc.DocumentNode.SelectNodes(
                    "//article[contains(@class, 'item-news')]/p[contains(@class,'description')]/a");
            for (int i = 0; i < listNode.Count; i++)
            {
                Article article = new Article();
                article.Url = listNode.ElementAt(i).Attributes["href"].Value;
                article.Title = listNode.ElementAt(i).InnerText;
                article.Images = image.ElementAt(i).Attributes["src"].Value;
                article.Content = content.ElementAt(i).InnerText;
                listArticleVnex.Add(article);
            }
            
            for (int j = 0; j < listArticleVnex.Count; j++)
            {
                Console.WriteLine($"Bài viết {j+1}");
                Console.WriteLine($"Url: {listArticleVnex[j].Url}");
                Console.WriteLine($"Title: {listArticleVnex[j].Title}");
                Console.WriteLine($"Image: {listArticleVnex[j].Images}");
                Console.WriteLine($"Content: {listArticleVnex[j].Content}");
                Console.WriteLine("-----------------------------------------------------------------------------------");
            }
            return null;
        }
    }
}