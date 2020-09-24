using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Controllers
{
    public class PartnerController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: Partner
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Chennelpartner()
        {
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            return View();
        }
        [HttpPost]
        public ActionResult SaveChennelPartnerDetails(FormCollection fc, ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            // var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
            var k = 0;
            foreach (HttpPostedFileBase file in postedFile)
            {
                if (file != null)
                {
                    var filename = Path.GetFileName(file.FileName);
                    if (k == 0)
                    {
                        var filename1 = Path.GetFileName(file.FileName);
                        if (filename1 != null)
                        {
                            var filePath = Server.MapPath("~/Documents/Logo/" + filename1);
                            file.SaveAs(filePath);
                        }
                    }
                    else if (k == 1)
                    {
                        var filePath = Server.MapPath("~/Documents/Pan/" + filename);
                        file.SaveAs(filePath);
                    }
                    else if (k == 2)
                    {
                        var path = Path.Combine(Server.MapPath("~/Documents/RegDocument"), filename);
                        file.SaveAs(path);
                    }
                    else if (k == 3)
                    {
                        var path = Path.Combine(Server.MapPath("~/Documents/ProfilePhoto"), filename);
                              file.SaveAs(path);
                    }
                    else if (k == 4)
                    {
                        var path = Path.Combine(Server.MapPath("~/Documents/OwnerSignature"), filename);
                        file.SaveAs(path);
                    }
                    k++;
                }
            }
            var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
            ViewBag.ChennelPartnerList = ChennelPartnerList;

            return View();
        }
    }
}