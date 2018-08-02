using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Services;
using System.Web.Services;

namespace AFWAJ_WS
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        
        public string HelloWorld()
        {
            SqlDataAdapter dadpt = new SqlDataAdapter("SELECT * FROM routes FOR JSON PATH", WebConfigurationManager.ConnectionStrings["AfwajDB2ConnectionString"].ConnectionString);
            DataSet dset = new DataSet();
            dadpt.Fill(dset);
            return dset.Tables[0].Rows[0][0].ToString();
 
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string ALL_ROUTES()
        {
            SqlDataAdapter dadpt = new SqlDataAdapter("select * from Routes FOR JSON PATH", WebConfigurationManager.ConnectionStrings["AfwajDB2ConnectionString"].ConnectionString);
            DataSet dset = new DataSet();
            dadpt.Fill(dset);
            return dset.Tables[0].Rows[0][0].ToString();

        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GuideID_ROUTES( )
        {
            SqlDataAdapter dadpt = new SqlDataAdapter("select * from Routes where GuideID =12345 FOR JSON PATH", WebConfigurationManager.ConnectionStrings["AfwajDB2ConnectionString"].ConnectionString);
            DataSet dset = new DataSet();
            dadpt.Fill(dset);
            return dset.Tables[0].Rows[0][0].ToString();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string HajMaster( string haj_id)
        {
            SqlDataAdapter dadpt = new SqlDataAdapter("select * from HajMaster where hajid = 1  FOR JSON PATH", WebConfigurationManager.ConnectionStrings["AfwajDB2ConnectionString"].ConnectionString);
            DataSet dset = new DataSet();
            dadpt.Fill(dset);
            return dset.Tables[0].Rows[0][0].ToString();

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string hajlist_ingroup(string haj_id)
        {
            SqlDataAdapter dadpt = new SqlDataAdapter("select * from HajMaster   FOR JSON PATH", WebConfigurationManager.ConnectionStrings["AfwajDB2ConnectionString"].ConnectionString);
            DataSet dset = new DataSet();
            dadpt.Fill(dset);
            return dset.Tables[0].Rows[0][0].ToString();

        }

    }
}
