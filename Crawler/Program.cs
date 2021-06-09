using System;
using System.Text;
using Crawler.Cr;
using Crawler.Menu;

namespace Crawler
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ApplicationMenu menu = new ApplicationMenu();
            menu.Menu();
        }
    }
}