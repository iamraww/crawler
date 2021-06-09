using System;
using System.Runtime.InteropServices;
using Crawler.Cr;

namespace Crawler.Menu
{
    public class ApplicationMenu
    {
        public void Menu()
        {
            DanTriCrawler danTriCrawler = new DanTriCrawler();
            VnexpressCrawler vnexpressCrawler = new VnexpressCrawler();
            while (true)
            {
                Console.WriteLine("Application Menu");
                Console.WriteLine("Bạn muốn đọc tin tức từ trang web nào?");
                Console.WriteLine("1. Dantri.com.vn");
                Console.WriteLine("2. Vnexpress.net");
                Console.WriteLine("0. Thôi !!!");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        danTriCrawler.CrawlerHtml();
                        break;
                    case 2:
                        vnexpressCrawler.CrawlerHtml();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                }

                if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}