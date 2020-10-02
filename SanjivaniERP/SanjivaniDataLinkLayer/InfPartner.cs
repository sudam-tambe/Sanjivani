using SanjivaniModalView;
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
        int SaveCPCDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile);
        int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile);
        List<State> GetBindState();
        List<CPCategory> GetBindCPCategory();
        List<CPCustomer> GetBindCPCustomer();
        List<CompanyType> GetBindCompanyType();
        List<ChennelpartnerModel> GetChennelPartnerList();
        List<CPCchannelPartnerModel> GetCPCChannelPartnerList();
        int SaveUploadChennelPartnerDocument(string filename1, int CustID, int type);
        int SaveUploadCPCDocument(string filename1, int CustID, int type);
        
        List<Account> getAccountType();
        List<PaymentType> getPaymentmode();
        CPCchannelPartnerModel GetCPCChannelList(int custId);
    }
}
