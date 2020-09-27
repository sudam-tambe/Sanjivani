using BandooDataLinkLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using System.Data.SqlClient;
using System.Data;
using SanjivaniModalView;
using System.Web;
using System.IO;

namespace SanjivaniDataLinkLayer
{
    public class ImpPartner : InfPartner
    {
        DBConnection objcon = new DBConnection();

        public List<State> GetBindState()
        {
            SqlCommand dinsert = new SqlCommand("Sp_BindState");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<State> lis = new List<State>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    State objstate = new State();
                    objstate.StateId = int.Parse(dr["StateId"].ToString());
                    objstate.StateName = dr["State"].ToString();
                    lis.Add(objstate);
                }
            }
            return lis;
        }
        public List<CPCategory> GetBindCPCategory()
        {
            SqlCommand dinsert = new SqlCommand("Sp_BindCpCategory");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCategory> list = new List<CPCategory>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCategory objCPCategory = new CPCategory();
                    objCPCategory.CategoryId = int.Parse(dr["CategoryId"].ToString());
                    objCPCategory.CategoryName = dr["CategoryName"].ToString();
                    list.Add(objCPCategory);
                }
            }
            return list;
        }
        public List<CompanyType> GetBindCompanyType()
        {
            SqlCommand dinsert = new SqlCommand("Sp_CompanyType");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CompanyType> list = new List<CompanyType>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CompanyType objCompanyType = new CompanyType();
                    objCompanyType.Compid = int.Parse(dr["Compid"].ToString());
                    objCompanyType.CompanyName = dr["CompanyName"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        

        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            SqlCommand dinsert = new SqlCommand("Sp_ChhenelPartnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<ChennelpartnerModel> list = new List<ChennelpartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    ChennelpartnerModel objChennelpartnerList = new ChennelpartnerModel();

                    objChennelpartnerList.RegiDate = Convert.ToDateTime(dr["RegistrationDate"].ToString());
                    objChennelpartnerList.UserName = dr["UserId"].ToString();
                    objChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objChennelpartnerList.EmailID = dr["Email"].ToString();
                    objChennelpartnerList.Address = dr["Address"].ToString();
                    list.Add(objChennelpartnerList);
                }
            }
            return list;
        }



        public int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile)
        {

            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.UserName.ToString()!="")
            dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserName;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;
          
                dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;
           
                dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;
            
                dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            
                dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;
            
                dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.chennelpartName;
            dinsert.Parameters.AddWithValue("@CPCategeoryId", SqlDbType.VarChar).Value = model.CpCategory;
            dinsert.Parameters.AddWithValue("@ParentId", SqlDbType.Int).Value = model.ParentId;
            dinsert.Parameters.AddWithValue("@AspUserId", SqlDbType.NVarChar).Value = model.AspUserId;
            dinsert.Parameters.AddWithValue("@CustCategroryId", SqlDbType.Int).Value = model.CustCategroryId;
            //dinsert.Parameters.AddWithValue("@DomainAddress", SqlDbType.NVarChar).Value = model.Address;
            var Result = objcon.GetExcuteScaler(dinsert);

            if (Result != null)
            {
                SqlCommand dinsert1 = new SqlCommand("Sp_SaveBankDetails");
                dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Result;
                
                    dinsert1.Parameters.AddWithValue("@BankName", SqlDbType.VarChar).Value = model.ObjBackDetails.BankName;
                
                    dinsert1.Parameters.AddWithValue("@AccountNo", SqlDbType.VarChar).Value = model.ObjBackDetails.AccountNumber;
               
                    dinsert1.Parameters.AddWithValue("@IFSCCode", SqlDbType.VarChar).Value = model.ObjBackDetails.IFSCcode;
               
                    dinsert1.Parameters.AddWithValue("@CardName", SqlDbType.VarChar).Value = model.ObjBackDetails.PaymentBankCardName;
               
                    dinsert1.Parameters.AddWithValue("@FourDigitCardNo", SqlDbType.VarChar).Value = model.ObjBackDetails.cardnumber;
               
                    dinsert1.Parameters.AddWithValue("@PaymentModeId", SqlDbType.Int).Value = model.ObjBackDetails.paymentMode;
               
                    dinsert1.Parameters.AddWithValue("@AccountTypeId", SqlDbType.Int).Value = model.ObjBackDetails.AccountType;
                var Result1 = objcon.GetExcuteScaler(dinsert1);
            }
            if (Result != null)
            {
                SqlCommand dinsert1 = new SqlCommand("Sp_SaveBusinessDetails");
                dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Result;
               
                    dinsert1.Parameters.AddWithValue("@CompanyName", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyName;
                
                    dinsert1.Parameters.AddWithValue("@CompanyType", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyType;
                
                    dinsert1.Parameters.AddWithValue("@CompRegNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.RegNumber;
               
                    dinsert1.Parameters.AddWithValue("@CompGSTNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.GSTRegNumber;
                
                    dinsert1.Parameters.AddWithValue("@CompWebsite", SqlDbType.VarChar).Value = model.ObjBusinessDetails.webSite;
                
                    dinsert1.Parameters.AddWithValue("@LineOfBusiness", SqlDbType.VarChar).Value = model.ObjBusinessDetails.LineofBusiness;
                
                    dinsert1.Parameters.AddWithValue("@AnnualTurnOver", SqlDbType.Decimal).Value = model.ObjBusinessDetails.Annulturnoveer;
               
                    dinsert1.Parameters.AddWithValue("@ContactPersonName", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CommanyName;
                
                    dinsert1.Parameters.AddWithValue("@DesignationId", SqlDbType.Int).Value = model.ObjBusinessDetails.Designation;
                
                    dinsert1.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.BContactnumber;
               
                    dinsert1.Parameters.AddWithValue("@AlternatContactNo", SqlDbType.VarChar).Value = model.ObjBusinessDetails.ABContactnumber;
                
                    dinsert1.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = model.ObjBusinessDetails.Emailid;
               
                    dinsert1.Parameters.AddWithValue("@CurrentERP", SqlDbType.VarChar).Value = model.ObjBusinessDetails.ERP;
                
                    dinsert1.Parameters.AddWithValue("@HostingPlatForm", SqlDbType.VarChar).Value = model.ObjBusinessDetails.HostingPlatform;
                
                    dinsert1.Parameters.AddWithValue("@TypeOfHosting", SqlDbType.VarChar).Value = model.ObjBusinessDetails.TypeofHosting;
               
                    dinsert1.Parameters.AddWithValue("@NoOfWebSiteHosted", SqlDbType.Int).Value = model.ObjBusinessDetails.NoOfWebSiteHos;
                
                    dinsert1.Parameters.AddWithValue("@CurrentEmailProvider", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CurrentEmailProvider;
               
                    dinsert1.Parameters.AddWithValue("@CountOfEmail", SqlDbType.Int).Value = model.ObjBusinessDetails.CountofEmail;
                
                    dinsert1.Parameters.AddWithValue("@CurrentDomailProvider", SqlDbType.VarChar).Value = model.ObjBusinessDetails.CurrentDomainProvide;
                
                    dinsert1.Parameters.AddWithValue("@CountOfDomain", SqlDbType.Int).Value = model.ObjBusinessDetails.CurrentDomainCount;
                
                    dinsert1.Parameters.AddWithValue("@CountOfSSL", SqlDbType.Int).Value = model.ObjBusinessDetails.SSLCertificateCount;
               
                    dinsert1.Parameters.AddWithValue("@OfficeAddress", SqlDbType.VarChar).Value = model.ObjBusinessDetails.OfficeAddres;
                
                    dinsert1.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.ObjBusinessDetails.Bstate;

                var Result1 = objcon.GetExcuteScaler(dinsert1);


            }
            return Result;

        }
        public int SaveUploadChennelPartnerDocument(string fileName, int CustID, int type)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_uploadUserDocuments");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            dinsert1.Parameters.AddWithValue("@fileName", SqlDbType.VarChar).Value = fileName;
            dinsert1.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }
        public List<Account> getAccountType()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetAccountype");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<Account> list = new List<Account>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    Account objCompanyType = new Account();
                    objCompanyType.AccountTypeId = int.Parse(dr["AccountTypeId"].ToString());
                    objCompanyType.AccountType = dr["AccountType"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public List<PaymentType> getPaymentmode()
        {
            SqlCommand dinsert = new SqlCommand("usp_GetPaymentMode");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<PaymentType> list = new List<PaymentType>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    PaymentType objCompanyType = new PaymentType();
                    objCompanyType.PaymentModeId = int.Parse(dr["PaymentModeId"].ToString());
                    objCompanyType.PaymentMode = dr["PaymentMode"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
    }
}
