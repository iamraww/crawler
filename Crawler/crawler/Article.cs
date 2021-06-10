﻿namespace Crawler.crawler
{
    public class Article
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Images { get; set; }

        public override string ToString()
        {
            return $"Url: {Url}, title: {Title}, image: {Images}, content: {Content}";
        }
        
        public string ToShortString()
        {
            return $"Url: {Url}, title: {Title}";
        }
    }
}