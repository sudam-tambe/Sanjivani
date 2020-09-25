﻿using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections;

namespace SanjivaniDataLinkLayer
{
    public interface InfPartner
    {
        int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile);
        List<State> GetBindState();
        List<CPCategory> GetBindCPCategory();
        List<CompanyType> GetBindCompanyType();
        List<ChennelpartnerModel> GetChennelPartnerList();
        int SaveUploadChennelPartnerDocument(string filename1, int CustID, int type);
        List<Account> getAccountType();
        List<PaymentType> getPaymentmode();
    }
}
