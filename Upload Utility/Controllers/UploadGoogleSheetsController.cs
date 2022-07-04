using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upload_Utility.Business;
using Upload_Utility.Models;

namespace Upload_Utility.Controllers
{
    public class UploadGoogleSheetsController : Controller
    {
        // GET: UploadGoogleSheets
        [HttpGet]
        public ActionResult Index()
        {
            var sheetData = new SheetDetails();
            return View(sheetData);
        }

        [HttpPost]
        public ViewResult Index(SheetDetails metData)
        {
            ReadGoogleSheets read = new ReadGoogleSheets(metData.SheetURL);
            var path = Server.MapPath(@"~/credential.json");
            var tokenPath = Server.MapPath(@"~/token.json");
            var sheetjson =  read.ReadFromGoogleSheets(path,tokenPath);
            metData.SheetMetaData = new List<SheetMetaData>();
            for (int i = 0; i < sheetjson.Length; i++)
            {
                var tempData = sheetjson[i].Split('|');
                var sheetData = new SheetMetaData();
                sheetData.StudentName = tempData[0];
                sheetData.Gender = tempData[1];
                sheetData.Class = tempData[2];
                sheetData.State = tempData[3];
                sheetData.Major = tempData[4];
                sheetData.Activity = tempData[5];
                metData.SheetMetaData.Add(sheetData);
            }
            return View(metData);
        }
    }
}