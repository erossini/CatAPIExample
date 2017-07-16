using CatAPI.Code.WebClient;
using CatAPI.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CatAPI.Controllers
{
    public class HomeController : Controller
    {
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<ActionResult> Index(string category = "")
        {
            log.Debug("Application starts");
            ViewBag.Category = category;

            CategoryWebClient client = new CategoryWebClient();
            List<Category> categories = await client.GetCategoriesAsync();

            Search search = new Search();
            search.Categories = categories;

            if (!string.IsNullOrEmpty(category))
            {
                ImageWebClient imgClient = new ImageWebClient();
                List<Image> images = await imgClient.GetImagesAsync(category, 12);
                search.Images = images;
            }

            return View(search);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}