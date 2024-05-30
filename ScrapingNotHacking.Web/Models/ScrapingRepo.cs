using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace ScrapingNotHacking.Web.Models
{
    public class ScrapingRepo
    {
        public List<Article> ScrapeArticles()
        {
            string url = "https://thelakewoodscoop.com";
            HttpClient client = new HttpClient();
            string theHtml =  client.GetStringAsync(url).Result;

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(theHtml);
            IHtmlCollection<IElement> siftedResults = document.QuerySelectorAll("div.td-category-pos-image");

            List<Article> magazine = new List<Article>();

            foreach(IElement thing in siftedResults)
            {
                Article modernArt = new Article();

                modernArt.Title = thing.QuerySelector(".entry-title.td-module-title").TextContent;
                modernArt.Image = thing.QuerySelector("span.entry-thumb").Attributes["data-img-url"].Value;
                modernArt.DatePosted = DateTime.Parse(thing.QuerySelector(".entry-date.updated.td-module-date").TextContent);
                modernArt.About = thing.QuerySelector(".td-excerpt").TextContent;
                modernArt.Url = thing.QuerySelector("h3.td-module-title a").Attributes["href"].Value;

                magazine.Add(modernArt);
            }

            Console.WriteLine(magazine.Count);

            return magazine;
        }
    }
}
