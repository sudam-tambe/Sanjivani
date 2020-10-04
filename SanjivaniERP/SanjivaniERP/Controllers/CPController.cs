﻿using SanjivaniBusinessLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SanjivaniERP.Controllers
{
    public class CPController : Controller
    {
        ClsPartnerBAL objPartnerBAL = new ClsPartnerBAL();
        // GET: CP
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult NewCp()
        {
            return View();
        }
        public ActionResult ChannelPartner()
        {
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype= new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCompanyType = new SelectList(objPartnerBAL.BindCompanyType(), "Compid", "CompanyName");
            return View();
        }
        public ActionResult CPCChennelPartner(int CustId)
        {
            CPCchannelPartnerModel list = new CPCchannelPartnerModel();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            ViewBag.BindCPCategory = new SelectList(objPartnerBAL.GetBindCPCategory(), "CategoryId", "CategoryName");
            ViewBag.BindCPCustomer = new SelectList(objPartnerBAL.GetBindCPCustomer(), "CpCustomer", "CpCustomerName");
            if(CustId>0)
            {
                if (!string.IsNullOrWhiteSpace(CustId.ToString()))
                {
                    list = objPartnerBAL.GetCPCChannelEdit(CustId);
                    return View(list);
                }
            }
            return View();
        }
        public ActionResult CPCChennelPartnerList()
        {
            var CPCChennelPartnerList = objPartnerBAL.GetCPCChannelPartnerList();
            ViewBag.CPCChennelPartnerList = CPCChennelPartnerList;
            return View();
        }
        public ActionResult DirectorBusinessOwnersList()
        {
            List<DirectorBusinessModel> DirectorModel =objPartnerBAL.GetDirectorBusinessOwnerList();
            ViewBag.DirectorBusinessOwnerList = DirectorModel;
            return View();
        }
        public ActionResult DirectorBusinessOwners(int CustId)
        {
            DirectorBusinessModel list = new DirectorBusinessModel();
            ViewBag.PaymentMode = new SelectList(objPartnerBAL.GetPaymentmode(), "PaymentModeId", "PaymentMode");
            ViewBag.Accountype = new SelectList(objPartnerBAL.GetAccountType(), "AccountTypeId", "AccountType");
            ViewBag.StateList = new SelectList(objPartnerBAL.GetBindState(), "StateId", "StateName");
            if (CustId > 0)
            {
                if (!string.IsNullOrWhiteSpace(CustId.ToString()))
                {
                    list = objPartnerBAL.GetDirectorBusinessOwners(CustId);
                    return View(list);
                }
            }
            return View();
        }
    }
}