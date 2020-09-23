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
            var EventsTitleList = objPartnerBAL.SaveChennelPartnerDetails(model, postedFile);
            var ChennelPartnerList = objPartnerBAL.GetChennelPartnerList();
            ViewBag.ChennelPartnerList = ChennelPartnerList;

            return View();
        }
    }
}