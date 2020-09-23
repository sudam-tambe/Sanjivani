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

        public List<State> GetBindState()
        {
            return objInfPub.GetBindState();
        }
        public List<CPCategory> GetBindCPCategory()
        {
            return objInfPub.GetBindCPCategory();
        }

        public List<ChennelpartnerModel> GetChennelPartnerList()
        {
            return objInfPub.GetChennelPartnerList();
        }
    }
}
