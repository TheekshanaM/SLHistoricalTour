using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace SLHistoricalTour.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string search, int? page)
        {
            string[] Place = { "Abhayagiri dagaba", "Aukana Buddha Statue", "Gal Viharaya", "Isurumuniya Viharaya",
                      "Jethawanaramaya Dagaba", "Kuttam Pokuna", "Lankatilaka Vihara", "Mirisawetiya Dagaba",
                        "Ruwanweliseya","Samadhi Buddha Statue","Sandakada pahana", "Thuparamaya Dagaba" };


            if(search != null)
            {
                int i = 0;
                string sPattern = "^" + search;
                foreach (string s in Place)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        i++;
                    }

                }
                string[] searched = new string[i];
                i = 0;
                foreach (string s in Place)
                {
                    if (System.Text.RegularExpressions.Regex.IsMatch(s, sPattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
                    {
                        searched[i] = s;
                        i++;
                    }

                }
                return View(searched.ToList().ToPagedList(page ?? 1, 8));
            }
            return View(Place.ToList().ToPagedList(page ?? 1,8));
        }

        public ActionResult VirtualView(string name) {
            name = Regex.Replace(name, " ", "");
            ViewBag.Massege = ConfigurationManager.AppSettings["Host"].ToString() + "Image/Panorama/"+name+".jpg";
            return View();
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