using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniModalView
{
    public class ChennelpartnerModel
    {
        public string RegiDate { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string pwd { get; set; }
        [Required]
        public string Cpwd { get; set; }
        public string chennelpartName { get; set; }
        [Required]
        public string mobileNo { get; set; }
        public string AlterMobileNo { get; set; }
        public string EmailID { get; set; }
        public int CpCategory { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public BankDetails ObjBackDetails { get; set; }
        public BusinessDetails ObjBusinessDetails { get; set; }
        public List<State> objState { get; set; }
        public List<CPCategory> ObjCPCategory { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

    }
    public class BankDetails
    {
        [Required]
        public string BankName { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public string IFSCcode { get; set; }

        public string PaymentBankCardName { get; set; }
        public string cardnumber { get; set; }
        public int paymentMode { get; set; }
        public int AccountType { get; set; }
    }

    public class BusinessDetails
    {
        public string CommanyName { get; set; }
        public string CommanyType { get; set; }

        public string RegNumber { get; set; }
        public string GSTRegNumber { get; set; }
        public string webSite { get; set; }
        public string LineofBusiness { get; set; }
        public decimal Annulturnoveer { get; set; }
        public string personalName { get; set; }
        public int Designation { get; set; }
        public string BContactnumber { get; set; }
        public string ABContactnumber { get; set; }
        public string Emailid { get; set; }
        public string ERP { get; set; }

        public string HostingProvider { get; set; }
        public string HostingPlatform { get; set; }
        public string TypeofHosting { get; set; }

        public int NoOfWebSiteHos { get; set; }

        public string CurrentEmailProvider { get; set; }
        public int CountofEmail { get; set; }
        public string CurrentDomainProvide { get; set; }
        public int CurrentDomainCount { get; set; }
        public string SSLCertificateCount { get; set; }

        public string OfficeAddres { get; set; }
        public int Bstate { get; set; }

    }
    
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get; set; }
    }
    public class CPCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
