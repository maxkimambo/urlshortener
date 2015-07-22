using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shorty.Core;

namespace Shorty.Web.Controllers
{
    public class ListController : Controller
    {
        private readonly IShortener _shortener;

        public ListController(IShortener shortener)
        {
            _shortener = shortener;
        }

        // GET: List
        public ActionResult Index()
        {
            var urls = _shortener.GetAll();

            return View(urls);
        }
    }
}