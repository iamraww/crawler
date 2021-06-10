using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;

namespace Crawler.crawler
{
    public class CrawlerVnexpress: ICrawler
    {
        public Article CrawDetail(string url)
        {
            Article article = new Article();
            List<Article> list = new List<Article>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var titleNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//h1[contains(@class, 'title-detail')]");
            article.Title = titleNode.InnerText;
            
            var contentNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//article[contains(@class, 'fck_detail')]");
            article.Content = contentNode.InnerHtml;
            
            var imageNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//figure/div[contains(@class, 'fig-picture')]/picture/image");
            article.Images = imageNode.Attributes["src"].Value;
            
            list.Add(article);
            return article;
        }

        public List<string> CrawUrl(string url)
        {
            
            List<string> listUrl = new List<string>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var listNode =
                htmlDocument.DocumentNode.SelectNodes(
                    "//article[contains(@class, 'item-news')]/h3[contains(@class,'title-news')]/a");
            for (int i = 0; i < listNode.Count; i++)
            {
                listUrl.Add(listNode.ElementAt(i).Attributes["href"].Value);
            }
            return listUrl;
        }
    }
}