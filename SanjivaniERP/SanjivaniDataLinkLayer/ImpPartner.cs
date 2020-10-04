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
        public List<CPCchannelPartnerModel> GetBindCPCustomer()
        {
            SqlCommand dinsert = new SqlCommand("Sp_ChannelPartnerCustomerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCchannelPartnerModel> list = new List<CPCchannelPartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCchannelPartnerModel objCPCust = new CPCchannelPartnerModel();
                    objCPCust.CpCustomer = (dr["CustId"].ToString());
                    objCPCust.CpCustomerName = dr["UserId"].ToString();
                    list.Add(objCPCust);
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

                    objChennelpartnerList.StatusId =(dr["StatusId"].ToString());
                    objChennelpartnerList.chennelpartName = dr["CustName"].ToString();
                    objChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objChennelpartnerList.EmailID = dr["Email"].ToString();
                    objChennelpartnerList.CommanyName = dr["CompanyName"].ToString();
                    objChennelpartnerList.CustId = dr["CustId"].ToString();
                    objChennelpartnerList.CPId = dr["CPId"].ToString();

                    list.Add(objChennelpartnerList);
                }
            }
            return list;
        }
        public List<CPCchannelPartnerModel> GetCPCChannelPartnerList()
        {
            SqlCommand dinsert = new SqlCommand("Sp_CPCChannelPartnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<CPCchannelPartnerModel> list = new List<CPCchannelPartnerModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    CPCchannelPartnerModel objCPCChennelpartnerList = new CPCchannelPartnerModel();
                    objCPCChennelpartnerList.CustId =Convert.ToString(dr["CustId"]);
                    objCPCChennelpartnerList.RegiDate =(dr["RegistrationDate"].ToString());
                    objCPCChennelpartnerList.UserId = dr["UserId"].ToString();
                    objCPCChennelpartnerList.mobileNo = dr["MobileNo"].ToString();
                    objCPCChennelpartnerList.EmailID = dr["Email"].ToString();
                    objCPCChennelpartnerList.Address = dr["Address"].ToString();
                    list.Add(objCPCChennelpartnerList);
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
            if (!string.IsNullOrWhiteSpace(model.CustId))
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(model.CustId);
            else
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = Convert.ToInt32(0);
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

        public int SaveCPCDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_SaveCPCRegistrationDetails");
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustomerName", SqlDbType.VarChar).Value = model.CustomerName;
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
            return Result;
        }

        public int SaveDirectorBusinessDetails(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertDirectorDetails");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;

            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;

            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.OwnerName;
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
            return Result;
        }
public ChennelpartnerModel getChannalPartnerDtl(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataSet dtList = objcon.GetDsByCommand(dinsert);
            ChennelpartnerModel list = new ChennelpartnerModel();

            if (dtList.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Tables[0].Rows)
                {


                    list.RegiDate = (dr["RegistrationDate"].ToString());
                    list.CPId = dr["CPId"].ToString();
                    list.CpCategory = dr["CPCategeoryId"].ToString();
                    list.UserName = dr["UserId"].ToString();
                    list.pwd = dr["Password"].ToString();
                    list.Cpwd = dr["Password"].ToString();
                    list.CustId = dr["CustId"].ToString();
                    list.chennelpartName = dr["CustName"].ToString();
                    list.mobileNo = dr["MobileNo"].ToString();
                    list.AlterMobileNo = dr["AlternateMobileNo"].ToString();
                    list.EmailID = dr["Email"].ToString();
                    list.Address = dr["Address"].ToString();
                    list.State = dr["StateId"].ToString();
                   // list.Address = dr["ParentId"].ToString();
                   // list.CustCategroryId = dr["CustomerType"].ToString();
                    list.CustCategroryId = dr["CustCategroryId"].ToString();
                    // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();
                   
                }
                foreach (DataRow dr in dtList.Tables[1].Rows)
                {

                    BankDetails list1 = new BankDetails();
                    list1.BankName = (dr["BankName"].ToString());
                    list1.AccountNumber = dr["AccountNo"].ToString();
                    list1.IFSCcode = dr["IFSCCode"].ToString();
                    list1.PaymentBankCardName = dr["CardName"].ToString();
                    list1.cardnumber = dr["FourDigitCardNo"].ToString();
                    list1.paymentMode = dr["PaymentModeId"].ToString();
                    list1.AccountType = dr["AccountTypeId"].ToString();
                    list.ObjBackDetails = list1;
                    // objCPCChennelpartnerList.Address = dr["CustCategroryId"].ToString();

                }
                foreach (DataRow dr in dtList.Tables[2].Rows)
                {

                    BusinessDetails list1 = new BusinessDetails();
                    list1.CommanyName = (dr["CompanyName"].ToString());
                    list1.CommanyType = dr["CompanyType"].ToString();
                    list1.RegNumber = dr["CompRegNo"].ToString();
                    list1.GSTRegNumber = dr["CompGSTNo"].ToString();
                    list1.webSite = dr["CompWebsite"].ToString();
                    list1.LineofBusiness = dr["LineOfBusiness"].ToString();
                    list1.Annulturnoveer = dr["AnnualTurnOver"].ToString();
                    list1.personalName = dr["ContactPersonName"].ToString();
                    list1.Designation = dr["DesignationId"].ToString();
                    list1.BContactnumber = dr["ContactNo"].ToString();
                    list1.ABContactnumber = dr["AlternatContactNo"].ToString();
                    list1.Emailid = dr["EmailId"].ToString();
                    list1.ERP = dr["CurrentERP"].ToString();
                    list1.HostingPlatform = dr["HostingPlatForm"].ToString();
                    list1.TypeofHosting = dr["TypeOfHosting"].ToString();
                    list1.NoOfWebSiteHos = dr["NoOfWebSiteHosted"].ToString();
                    list1.CurrentEmailProvider = dr["CurrentEmailProvider"].ToString();
                    list1.CountofEmail = dr["CountOfEmail"].ToString();
                    list1.CurrentEmailProvider = dr["CurrentDomailProvider"].ToString();
                    list1.CurrentDomainCount = dr["CountOfDomain"].ToString();
                    list1.SSLCertificateCount = dr["CountOfSSL"].ToString();
                    list1.OfficeAddres = dr["OfficeAddress"].ToString();
                    list1.Bstate = dr["StateId"].ToString();
                    list.ObjBusinessDetails = list1;

                }
            }
            return list;
        }
		public bool rejectChannalPartner(int custId)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_RejectChannelPartner");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
     
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public DataSet getFolder()
        {
            DataSet ds = new DataSet();
            SqlCommand dinsert = new SqlCommand("usp_getFolderAndFile");
            ds = objcon.GetDsByCommand(dinsert);
            return ds;
        }
        public List<UserIntraction> getUserIntraction(int custId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetUserintraction");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = custId;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<UserIntraction> list = new List<UserIntraction>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    UserIntraction objCompanyType = new UserIntraction();
                    objCompanyType.Intraction = (dr["Intraction"].ToString());
                   // objCompanyType.AccountType = dr["AccountType"].ToString();
                    list.Add(objCompanyType);
                }
            }
            return list;
        }
        public bool SetUserIntarction(UserIntraction usD)
        {
            SqlCommand dinsert1 = new SqlCommand("usp_SetUserIntarction");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = usD.CustId;
            dinsert1.Parameters.AddWithValue("@Intraction", SqlDbType.VarChar).Value = usD.Intraction;
            bool Result1 = objcon.InsrtUpdtDlt(dinsert1);
            return Result1;
        }
        public DataTable getLoginDetail(string id)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetLoginDetail");
            dinsert.Parameters.AddWithValue("@UserId", SqlDbType.NVarChar).Value = id;
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            return dtList;
        }
        public int UpdateCPCRegisterDetails(CPCchannelPartnerModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertPartnerDetails");
            if (model.CustId.ToString() != "")
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value =model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;
            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.CustomerName;
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
        public int SaveUploadCPCDocument(string fileName, int CustID, int type)
        {
            SqlCommand dinsert1 = new SqlCommand("Sp_uploadCPCUserDocuments");
            dinsert1.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            dinsert1.Parameters.AddWithValue("@fileName", SqlDbType.VarChar).Value = fileName;
            dinsert1.Parameters.AddWithValue("@type", SqlDbType.VarChar).Value = type;
            var Result1 = objcon.GetExcuteScaler(dinsert1);
            return Result1;
        }

        public CPCchannelPartnerModel GetCPCChannelList(int CustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            CPCchannelPartnerModel List = new CPCchannelPartnerModel();
            if (DsList.Tables[0].Rows[0] != null)
            {

                List.CustId =Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.RegiDate = (DsList.Tables[0].Rows[0]["RegistrationDate"].ToString());
                List.UserId = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.Cpwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.CustomerName = DsList.Tables[0].Rows[0]["CustName"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CustCategroryId = DsList.Tables[0].Rows[0]["CustCategroryId"].ToString();
                List.CpCategory = Convert.ToString(DsList.Tables[0].Rows[0]["CPCategeoryId"]);
                List.CpCustomer = Convert.ToString(DsList.Tables[0].Rows[0]["ParentId"]);
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.ObjBackDetails = getBankDetailsdata(CustID);
            }
                return List;
        }

        public List<DirectorBusinessModel> GetDirectorBusinessOwnerList()
        {

            SqlCommand dinsert = new SqlCommand("Sp_DirectorBusinessOwnerList");
            DataTable dtList = objcon.GetDtByCommand(dinsert);
            List<DirectorBusinessModel> List = new List<DirectorBusinessModel>();

            if (dtList.Rows.Count > 0)
            {
                foreach (DataRow dr in dtList.Rows)
                {
                    DirectorBusinessModel objDirectorBusinessList = new DirectorBusinessModel();
                    objDirectorBusinessList.CustId = Convert.ToString(dr["CustId"]);
                    objDirectorBusinessList.RegiDate =(dr["RegistrationDate"].ToString());
                    objDirectorBusinessList.UserId = dr["UserId"].ToString();
                    objDirectorBusinessList.mobileNo = dr["MobileNo"].ToString();
                    objDirectorBusinessList.EmailID = dr["Email"].ToString();
                    objDirectorBusinessList.Address = dr["Address"].ToString();
                    List.Add(objDirectorBusinessList);
                }
            }
            return List;
        }
        

        public BankDetails getBankDetailsdata(int CustID)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustID;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            BankDetails ObjBackDetails = new BankDetails();
            if (DsList.Tables[1].Rows[0] != null)
            {
                ObjBackDetails.BankName = DsList.Tables[1].Rows[0]["BankName"].ToString();
                ObjBackDetails.AccountNumber = Convert.ToString(DsList.Tables[1].Rows[0]["AccountNo"]);
                ObjBackDetails.IFSCcode = Convert.ToString(DsList.Tables[1].Rows[0]["IFSCCode"]);
                ObjBackDetails.PaymentBankCardName = Convert.ToString(DsList.Tables[1].Rows[0]["CardName"]);
                ObjBackDetails.cardnumber = Convert.ToString(DsList.Tables[1].Rows[0]["FourDigitCardNo"]);
                ObjBackDetails.paymentMode = Convert.ToString(DsList.Tables[1].Rows[0]["PaymentModeId"]);
                ObjBackDetails.AccountType = Convert.ToString(DsList.Tables[1].Rows[0]["AccountTypeId"]);
            }
            return ObjBackDetails;
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
     
        public int UpdateDirectorBusinessRegister(DirectorBusinessModel model, HttpPostedFileBase[] postedFile)
        {
            SqlCommand dinsert = new SqlCommand("Sp_InsertDirectorDetails");
            if (model.CustId.ToString() != "")
                dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = model.CustId;
            if (model.UserId.ToString() != "")
                dinsert.Parameters.AddWithValue("@UserId", SqlDbType.VarChar).Value = model.UserId;
            if (model.pwd.ToString() != null)
                dinsert.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = model.pwd;
            if (model.mobileNo.ToString() != null)
                dinsert.Parameters.AddWithValue("@MobileNo", SqlDbType.VarChar).Value = model.mobileNo;

            dinsert.Parameters.AddWithValue("@AlternateMobileNo", SqlDbType.VarChar).Value = model.AlterMobileNo;

            dinsert.Parameters.AddWithValue("@Email", SqlDbType.VarChar).Value = model.EmailID;
            dinsert.Parameters.AddWithValue("@Address", SqlDbType.VarChar).Value = model.Address;
            dinsert.Parameters.AddWithValue("@StateId", SqlDbType.Int).Value = model.State;

            dinsert.Parameters.AddWithValue("@CustName", SqlDbType.VarChar).Value = model.OwnerName;
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
            return Result;
        }

        public DirectorBusinessModel GetDirectorBusinessOwners(int CustId)
        {
            SqlCommand dinsert = new SqlCommand("usp_GetChannalPartner");
            dinsert.Parameters.AddWithValue("@CustId", SqlDbType.Int).Value = CustId;
            DataSet DsList = objcon.GetDsByCommand(dinsert);
            DirectorBusinessModel List = new DirectorBusinessModel();
            if (DsList.Tables[0].Rows[0] != null)
            {

                List.CustId = Convert.ToString(DsList.Tables[0].Rows[0]["CustId"]);
                List.RegiDate = (DsList.Tables[0].Rows[0]["RegistrationDate"].ToString());
                List.UserId = DsList.Tables[0].Rows[0]["UserId"].ToString();
                List.mobileNo = DsList.Tables[0].Rows[0]["MobileNo"].ToString();
                List.EmailID = DsList.Tables[0].Rows[0]["Email"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.pwd = DsList.Tables[0].Rows[0]["Password"].ToString();
                List.OwnerName = DsList.Tables[0].Rows[0]["CustName"].ToString();
                List.AlterMobileNo = DsList.Tables[0].Rows[0]["AlternateMobileNo"].ToString();
                List.Address = DsList.Tables[0].Rows[0]["Address"].ToString();
                List.CustCategroryId = DsList.Tables[0].Rows[0]["CustCategroryId"].ToString();
                List.State = Convert.ToString(DsList.Tables[0].Rows[0]["StateId"]);
                List.ObjBackDetails = getBankDetailsdata(CustId);
            }
            return List;
        }
    }
}
