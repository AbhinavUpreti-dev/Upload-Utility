using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upload_Utility.Models;

namespace Upload_Utility.Controllers
{
    public class UploadGoogleSheetsController : Controller
    {
        // GET: UploadGoogleSheets
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(SheetMetaData metData)
        {
            return View(metData);
        }
    }
}