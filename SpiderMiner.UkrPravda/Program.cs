using HtmlAgilityPack;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace SpiderMiner.UkrPravda
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //var web = new HtmlWeb();
                //var document = web.Load("https://www.pravda.com.ua/archives/date_01042000/");



                //var test = "Привіт усім";
                //Console.WriteLine(Encoding.

                // Print the header.
                //Console.Write("Info.CodePage      ");
                //Console.Write("Info.Name                    ");
                //Console.Write("Info.DisplayName");
                //Console.WriteLine();

                // Display the EncodingInfo names for every encoding, and compare with the equivalent Encoding names.
                //foreach (EncodingInfo ei in Encoding.GetEncodings())
                //{
                //    Encoding e = ei.GetEncoding();

                //    Console.Write("{0,-15}", ei.CodePage);
                //    if (ei.CodePage == e.CodePage)
                //        Console.Write("    ");
                //    else
                //        Console.Write("*** ");

                //    Console.Write("{0,-25}", ei.Name);
                //    if (ei.CodePage == e.CodePage)
                //        Console.Write("    ");
                //    else
                //        Console.Write("*** ");

                //    Console.Write("{0,-25}", ei.DisplayName);
                //    if (ei.CodePage == e.CodePage)
                //        Console.Write("    ");
                //    else
                //        Console.Write("*** ");

                //    Console.WriteLine();
                //}

                //const string source = "Ðàáîòà â ãåðìàíèè";
                //const string destination = "Работа в германии";

                //var test = Encoding.GetEncodings();
                //foreach (var sourceEncoding in Encoding.GetEncodings())
                //{

                //    var bytes = sourceEncoding.GetEncoding().GetBytes(source);
                //    foreach (var targetEncoding in Encoding.GetEncodings())
                //    {
                //        if (targetEncoding.GetEncoding().GetString(bytes) == destination)
                //        {
                //            Console.WriteLine("Source Encoding: {0} TargetEncoding: {1}", sourceEncoding.CodePage, targetEncoding.CodePage);
                //        }

                //    }
                //}
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static void ParsePage(string url)
        {
            var htmlDocument = new HtmlDocument();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var encoding = Encoding.GetEncoding(1251);
            Console.OutputEncoding = encoding;
            using (var webClient = new WebClient())
            {
                webClient.Encoding = encoding;
                webClient.Headers.Add("user-agent", "Test");
                var document = webClient.DownloadString(url);
                htmlDocument.LoadHtml(document);

                // article__title
                var newsTitles = htmlDocument.DocumentNode.SelectNodes("//body//div[@class='news news_all']//div[@class='article__title']");

                foreach (var title in newsTitles)
                {
                    Console.WriteLine(title.InnerText);
                }
            }
        }

        static void WriteData(string path, string data) 
        {
            File.AppendAllLines(path, new string[] { data });
        }
    }
}
