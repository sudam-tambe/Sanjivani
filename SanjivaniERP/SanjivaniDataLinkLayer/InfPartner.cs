using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections;
using System.Data;

namespace SanjivaniDataLinkLayer
{
    public interface InfPartner
    {
        int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile);
        int SaveCPCDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile);
        int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile);
        int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile);
        List<State> GetBindState();
        List<CPCategory> GetBindCPCategory();
        List<CPCchannelPartnerModel> GetBindCPCustomer();
        List<CompanyType> GetBindCompanyType();
        List<ChennelpartnerModel> GetChennelPartnerList();
        List<CPCchannelPartnerModel> GetCPCChannelPartnerList();
        int SaveUploadChennelPartnerDocument(string filename1, int CustID, int type);
        int SaveUploadCPCDocument(string filename1, int CustID, int type);
        int SaveUploadDirectorDoc(string filename1, int CustID, int type);

        ChennelpartnerModel getChannalPartnerDtl(int custId);
        bool rejectChannalPartner(int custId);
        DataSet getFolder();
        List<UserIntraction> getUserIntraction(int custId);
        bool SetUserIntarction(UserIntraction usD);
        DataTable getLoginDetail(string id);
        List<Account> getAccountType();
        List<BankName> GetBankName();

        List<PaymentType> getPaymentmode();
        bool setCPBusinessDtl(BusinessDetails bD);
        CPCchannelPartnerModel GetCPCChannelList(int custId);
       DirectorBusinessModel GetDirectorChannelEdit(int custId);
        List<DirectorBusinessModel> GetDirectorBusinessOwnerList();
        int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile);
        DirectorBusinessModel GetDirectorBusinessOwners(int CustId);
        int _PartialCPSave(ChennelpartnerModel model);
        int _SaveCPCPartialView(CPCchannelPartnerModel model);
        bool SetCPBankDtl(BankDetails bd);
        bool SetCPCBankDtl(BankDetails bd);
    }
}
