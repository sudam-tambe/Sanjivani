using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanjivaniModalView
{
    public class ChennelpartnerModel
    {
        public int UserName { get; set; }
        public string pwd { get; set; }
        public string Cpwd { get; set; }
        public string chennelpartName { get; set; }
        public int mobileNo { get; set; }
        public int AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public int CpCategory { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public List<BackDetails> ObjBackDetails { get; set; }
        public List<BusinessDetails> ObjBusinessDetails { get; set; }
    }
    public class BackDetails
    {
        public string BankName { get; set; }
        public int AccountNumber { get; set; }
        public int IFSCcode { get; set; }
        public string PaymentBankCardName { get; set; }
        public int cardnumber { get; set; }
        public string paymentMode { get; set; }
        public string AccountType { get; set; }
    }

    public class BusinessDetails
    {
        public string CommanyName { get; set; }
        public string CommanyType { get; set; }

        public string RegNumber { get; set; }
        public string GSTRegNumber { get; set; }
        public string wbeSite { get; set; }
        public string LineofBusiness { get; set; }
        public int Annulturnoveer { get; set; }
        public string personalName { get; set; }
        public string Designation { get; set; }
        public int BContactnumber { get; set; }
        public int ABContactnumber { get; set; }
        public string Emailid { get; set; }
        public int ERP { get; set; }

        public string HostingProvider { get; set; }
        public string HostingPlatform { get; set; }
        public string TypeofHosting { get; set; }

        public string NoOfWebSiteHos { get; set; }

        public string CurrentEmailProvider { get; set; }
        public int CountofEmail { get; set; }
        public string CurrentDomainProvide { get; set; }
        public int CurrentDomainCount { get; set; }
        public string SSLCertificateCount { get; set; }

        public string OfficeAddres { get; set; }
        public string Bstate { get; set; }

    }

}
