using SanjivaniDataLinkLayer;
using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Web;

namespace SanjivaniBusinessLayer
{
    public class ClsPartnerBAL
    {
        InfPartner objInfPub = new SanjivaniDataLinkLayer.ImpPartner();

        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveChennelPartnerDetails(model, postedFile);
        }
        public int SaveCPCRegisterDetails(CPCchannelPartnerModel model,HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveCPCDetails(model, postedFile);
        }

        public List<PaymentType> GetPaymentmode()
        {
            return objInfPub.getPaymentmode();
        }

        public List<Account> GetAccountType()
        {
            return objInfPub.getAccountType();
        }

        public List<State> GetBindState()
        {
            return objInfPub.GetBindState();
        }
        public List<CPCategory> GetBindCPCategory()
        {
            return objInfPub.GetBindCPCategory();
        }
        public List<CPCustomer> GetBindCPCustomer()
        {
            return objInfPub.GetBindCPCustomer();
        }
        

        public List<CompanyType> BindCompanyType()
        {
            return objInfPub.GetBindCompanyType();
        }


        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            return objInfPub.GetChennelPartnerList();
        }
        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList()
        {
            return objInfPub.GetCPCChannelPartnerList();
        }

        public int SaveUploadChennelPartnerDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadChennelPartnerDocument(filename1, CustID, type);
        }
        public int SaveUploadCPCDoc(string filename1, int CustID, int type)
        {
            return objInfPub.SaveUploadCPCDocument(filename1, CustID, type);
        }
        
    }
}
