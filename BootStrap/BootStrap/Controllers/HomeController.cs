using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Xml.Linq;
using Newtonsoft.Json;

namespace BootStrap.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GrabNews()
        {
           var res = LoadNews.GetNews();

           return Json(res, JsonRequestBehavior.AllowGet);
        }

    }

    public class LoadNews
    {
        public string filename = "test.json";
        private static NewsItem feedRead = new NewsItem();
        private static List<NewsItem> results = new List<NewsItem>();

        public static List<NewsItem> GetNews()
        {
            var serializer = new JsonSerializer();
            using (var re = File.OpenText(@"F:\Visual Studio Projects\BootStrap\BootStrap\Controllers\test.json"))
            using (var reader = new JsonTextReader(re))
            {              
                results = serializer.Deserialize<List<NewsItem>>(reader);
            }

            return results;
        }

    }



    public class NewsItem
    {
        private int _id;
        private string _time;
        private string _newsItems;
        private string _level;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public string Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string NewsItems
        {
            get { return _newsItems; }
            set { _newsItems = value; }
        }
    }
}
