using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Shorty.Core;

namespace Shorty.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortener _shortService;

        public HomeController(IShortener shortService)
        {
            _shortService = shortService;
        }

        public ActionResult Index()
        {
            var message = RouteData.Values["id"];

            ViewBag.Message = message; 

            return View();
        }


        public ActionResult Resolve(string id)
        {
            var url =  _shortService.ExpandUrl(id);

            //link couldnt be found so redirect 
            if (url == null)
            {
              return  RedirectToAction("LinkNotFound"); 
            }

            if (!(url.OriginalUrl.StartsWith("http") || url.OriginalUrl.StartsWith("https")))
            {
                // tack http to the begining of the url, otherwise redirection fails. 

                url.OriginalUrl = "http://" + url.OriginalUrl; 
            }

            return RedirectPermanent(url.OriginalUrl); 
        }

        public ActionResult LinkNotFound()
        {

            return View(); 
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Shorten(string url)
        {

            var userUrl = new UserDto()
            {
                OriginalUrl = url,
                CreatedOn = DateTime.Now,
                UserId = User.Identity.Name,
            };

            var result = _shortService.ShortenUrl(userUrl);




            // get current domain 
            var baseurl = GetBaseUrl();
            result.Url = baseurl + "1" + result.Url; 

            return Json(result); 
        }

        // Calculates base url of the app. 
        private string GetBaseUrl()
        {
            var baseurl = new StringBuilder();
            if (Request.Url != null)
            {
                baseurl.Append(Request.Url.Scheme);
                baseurl.Append("://");
                baseurl.Append(Request.Url.Authority);
            }
            if (Request.ApplicationPath != null) baseurl.Append(Request.ApplicationPath.TrimEnd());


            return baseurl.ToString(); 
        }
        public ActionResult About()
        {
          

            return View();
        }

        public ActionResult Contact()
        {

            return View();
        }

       
    }
}