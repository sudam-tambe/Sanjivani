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
using System.Data;

namespace SanjivaniBusinessLayer
{
    public class ClsPartnerBAL
    {
        InfPartner objInfPub = new SanjivaniDataLinkLayer.ImpPartner();

        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveChennelPartnerDetails(model, postedFile);
        }
        public int SaveCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveCPCDetails(model, postedFile);
        }

        public int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.SaveDirectorBusinessDetails(model, postedFile);
        }

        public int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateCPCRegisterDetails(model, postedFile);
        }
        public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            return objInfPub.UpdateDirectorBusinessRegister(model, postedFile);
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
        public List<CPCchannelPartnerModel> GetBindCPCustomer()
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

        public CPCchannelPartnerModel GetCPCChannelEdit(int custId)
        {
            return objInfPub.GetCPCChannelList(custId);
        }

        public List<DirectorBusinessModel> GetDirectorBusinessOwnerList()
        {
            return objInfPub.GetDirectorBusinessOwnerList();
        }
        public bool RejectChannalPartner(int CustId)
        {
            return objInfPub.rejectChannalPartner(CustId);
        }
        public DataTable GetLoginDetail(string id)
        {
            return objInfPub.getLoginDetail(id);
        }
        public DataSet GetFolder()
        {
            return objInfPub.getFolder();
        }

        public List<UserIntraction> GetUserIntraction(int custId)
        {
            return objInfPub.getUserIntraction(custId);
        }
        public bool setUserIntarction(UserIntraction usD)
        { 
            return objInfPub.SetUserIntarction(usD);

        }
        public ChennelpartnerModel GetChannalPartnerDtl(int custId)
        {
            return objInfPub.getChannalPartnerDtl(custId);
        }

        public DirectorBusinessModel GetDirectorBusinessOwners(int custId)
    {
        return objInfPub.GetDirectorBusinessOwners(custId);

    }
}
}
