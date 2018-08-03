using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFWAJ.Models;
using AFWAJ.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace AFWAJ.ViewModels
{
	public class UserTasksViewModel : BindableObject
    {
	    public ObservableCollection<ALL_ROUTES> UserRoutes;
        public delegate void LoadComplete();
        public event LoadComplete LoadDone;
        public UserTasksViewModel ()
        {
  
            LoadWS();
        }

	    async void LoadWS()
	    {
 
	        try
	        {
 	            var url = "http://afwaj.azurewebsites.net/WebService1.asmx";
	            var action = "ALL_ROUTES";
	            var soapAction = "http://tempuri.org/ALL_ROUTES";
	            var parms = new Dictionary<string, string>
	            {
	                { "P1", "1" },
	                { "P2", "1" },
	                { "Pass", "" }
	            };

	            string respo = await DataAccess.sharedService().SendSOAPRequestAsync(url,
	                action,
	                parms,
	                soapAction,
	                false);
                
	            UserRoutes = JsonConvert.DeserializeObject<ObservableCollection<Models.ALL_ROUTES>>(respo);
	            LoadDone();

	        }
	        catch (Exception e)
	        {
	            Debug.WriteLine(e);
	            //UserDialogs.Instance.Alert("Error Loading");
	        }
        }

	   
    }
}