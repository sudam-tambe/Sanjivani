using SanjivaniModalView;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SanjivaniDataLinkLayer
{
    public interface InfPartner
    {
        int SaveChennelPartnerDetails(ChennelpartnerModel model, HttpPostedFileBase[] postedFile);
        List<State> GetBindState();
        List<CPCategory> GetBindCPCategory();
        List<ChennelpartnerModel> GetChennelPartnerList();


    }
}
