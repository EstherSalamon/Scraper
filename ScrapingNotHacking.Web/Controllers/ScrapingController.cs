using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScrapingNotHacking.Web.Models;

namespace ScrapingNotHacking.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapingController : ControllerBase
    {
        [Route("scrapescoop")]
        public List<Article> ScrapeArticles()
        {
            ScrapingRepo repo = new ScrapingRepo();
            return repo.ScrapeArticles();
        }
    }
}
