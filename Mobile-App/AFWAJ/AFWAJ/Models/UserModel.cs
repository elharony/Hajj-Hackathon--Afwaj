using System;
using System.Collections.Generic;
using System.Text;

namespace AFWAJ.Models
{
    public class ALL_ROUTES
    {
        public int RouteID { get; set; }
        public string Rfrom { get; set; }
        public string RTo { get; set; }
        public string Rdate { get; set; }
        public int HajGroupID { get; set; }
        public int GuideID { get; set; }
        public string RfromL { get; set; }
        public string RtoL { get; set; }


    }


    public class GuideID_ROUTES
    {
        public int RouteID { get; set; }
        public string Rfrom { get; set; }
        public string RTo { get; set; }
        public string Rdate { get; set; }
        public int HajGroupID { get; set; }
        public int GuideID { get; set; }
        public string RfromL { get; set; }
        public string RtoL { get; set; }
        public string current_location { get; set; }
    }




    public class HajMaster
    {
        public int HAJID { get; set; }
        public string Name { get; set; }
        public string age { get; set; }
        public string photoURL { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }
        public int parent { get; set; }
    }


 

    public class hajlist_ingroup
    {
        public int HAJID { get; set; }
        public string Name { get; set; }
        public string age { get; set; }
        public string photoURL { get; set; }
        public string nationality { get; set; }
        public string gender { get; set; }
        public int parent { get; set; }
        public bool Status { get; set; }
        public string StatusColor { get; set; }

    }



}
