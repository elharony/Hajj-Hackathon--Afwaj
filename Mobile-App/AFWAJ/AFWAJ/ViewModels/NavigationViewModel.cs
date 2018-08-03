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
        public ObservableCollection<IBeacon> Detectedbeacons;
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

            var status = await EstimoteManager.Instance.Initialize();  
            if (status != BeaconInitStatus.Success)
            {
                
            }
            EstimoteManager.Instance.Ranged += OnInstanceOnRanged;
            EstimoteManager.Instance.StartRanging(new BeaconRegion("Estimote", "B9407F30-F5F8-466E-AFF9-25556B57FE6D"));
            EstimoteManager.Instance.RegionStatusChanged += OnInstanceOnRegionStatusChanged;
            Detectedbeacons = new ObservableCollection<IBeacon>();
            Detectedbeacons.CollectionChanged += DetectedbeaconsOnCollectionChanged;


        }

        public async void StopTracking()
        {
            EstimoteManager.Instance.StopAllRanging();
            EstimoteManager.Instance.StopAllMonitoring();
        }
        private void OnInstanceOnRegionStatusChanged(object sender, BeaconRegionStatusChangedEventArgs region)
        {

        }

        private void DetectedbeaconsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
             


                if (notifyCollectionChangedEventArgs.NewItems == null)
                {
                    return;
                }
            
            var Beacons = notifyCollectionChangedEventArgs.NewItems.Cast<IBeacon>().OrderByDescending(x => x.Major);

                
                    for (int i = 0; i < ListOfHajj.Count - 1; i++)
                 {
                     foreach (var beacon in Beacons)
                     {
                    if (ListOfHajj[i].HAJID == beacon.Major)
                        {
                            ListOfHajj[i].Status = 1;
                            ListOfHajj[i].StatusColor = "Green";
                        }
                        else
                        {
                            ListOfHajj[i].Status = 0;
                            ListOfHajj[i].StatusColor = "Red";
                        }
                    }
                }
                StatusUpdated();



           
           
        }

        private void OnInstanceOnRanged(object sender, IEnumerable<IBeacon> beacons)
        {


            var beaconsList = new ObservableCollection<IBeacon>(beacons);

            bool equalAB = beaconsList.SequenceEqual(Detectedbeacons, new BeaconComparer());

            if (!equalAB)
            {
                 Detectedbeacons.Clear();
                    foreach (var beacon in beaconsList)
                        Detectedbeacons.Add(beacon);
               

            }




        }
    }

       
            
        }
class BeaconComparer : IEqualityComparer<IBeacon>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(IBeacon x, IBeacon y)
    {

        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the products' properties are equal.
        return x.Major == y.Major && x.Minor == y.Minor;
    }

    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(IBeacon beacon)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(beacon, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashMajor = beacon.Major == null ? 0 : beacon.Major.GetHashCode();

        //Get hash code for the Code field.
        int hashMinor = beacon.Minor.GetHashCode();

        //Calculate the hash code for the product.
        return hashMajor ^ hashMinor;
    }

}







