using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace Crawler.crawler
{
    public class CrawlerDantri: ICrawler
    {
        public Article CrawDetail(string url)
        {
            Article article = new Article();
            List<Article> list = new List<Article>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var titleNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//h1[contains(@class, 'dt-news__title')]");
            article.Title = titleNode.InnerText;
            
            var contentNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//div[contains(@class, 'dt-news__content')]");
            article.Content = contentNode.InnerHtml;
            
            var imageNode =
                htmlDocument.DocumentNode.SelectSingleNode(
                    "//div[contains(@class, 'dt-news__content')]/figure/img");
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
                    "//div[contains(@class, 'news-item')]/h3[contains(@class,'news-item__title')]/a");
            for (int i = 0; i < listNode.Count; i++)
            {
                listUrl.Add($"http://dantri.com.vn{listNode.ElementAt(i).Attributes["href"].Value}");
            }
            return listUrl;
        }
    }
}