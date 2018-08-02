using AFWAJ.Models;
using AFWAJ.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using Estimotes;
using Xamarin.Forms;

namespace AFWAJ.ViewModels
{

    class NavigationViewModel : BindableObject
    {
        public ObservableCollection<IBeacon> Detectedbeacons ;
         public int timer { get; set; }
        public int timer2 { get; set; }
        public ObservableCollection<hajlist_ingroup> ListOfHajj { set; get; }

        public delegate void GroupStatus();

        public event GroupStatus StatusUpdated;
        public NavigationViewModel(ObservableCollection<hajlist_ingroup> _listofHajj)
        {
            ListOfHajj = _listofHajj;

            StartTracking();
            
        }

        public async void StartTracking()
        {

            var status = await EstimoteManager.Instance.Initialize(false);  
            if (status != BeaconInitStatus.Success)
            {
                
            }
            EstimoteManager.Instance.StartMonitoring(new BeaconRegion("Estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
            EstimoteManager.Instance.Ranged += OnInstanceOnRanged;
            EstimoteManager.Instance.RegionStatusChanged += OnInstanceOnRegionStatusChanged;



        }

        private void OnInstanceOnRegionStatusChanged(object sender, BeaconRegionStatusChangedEventArgs region)
        {

        }

        private void OnInstanceOnRanged(object sender, IEnumerable<IBeacon> beacons)
        {
            foreach (var beacon in beacons)
            {
                foreach (var hajj in ListOfHajj)
                {
                    if (hajj.HAJID == beacon.Major)
                    {
                        hajj.Status = true;
                        hajj.StatusColor = "Green";
                    }
                    else
                    {
                        hajj.Status = false;
                        hajj.StatusColor = "Red";
                    }
                    StatusUpdated();
                }
            }
           
        }
    }

       
            
        }

 
        

       

    
