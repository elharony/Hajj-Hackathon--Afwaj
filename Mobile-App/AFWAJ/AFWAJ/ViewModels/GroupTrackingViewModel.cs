using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using AFWAJ.Models;
using AFWAJ.Services;
using Newtonsoft.Json;

namespace AFWAJ.ViewModels
{
    class GroupTrackingViewModel
    {
        public ObservableCollection<hajlist_ingroup> ListOfHajj { set; get; }
        public delegate void LoadComplete();
        public event LoadComplete LoadDone;

        public GroupTrackingViewModel()
        {
            //LoadWS();
        }

        private async void LoadWS()
        {
            try
            {
                var url = "http://afwaj.azurewebsites.net/WebService1.asmx";
                var action = "hajlist_ingroup";
                var soapAction = "http://tempuri.org/hajlist_ingroup";
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

                ListOfHajj = JsonConvert.DeserializeObject<ObservableCollection<Models.hajlist_ingroup>>(respo);
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
