using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AFWAJ.Models;
using AFWAJ.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AFWAJ.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TripView : ContentPage
	{
	    private ObservableCollection<hajlist_ingroup> samples;
	    private NavigationViewModel _navigationViewModel;

        public TripView ()
		{
			InitializeComponent ();
		    hajlist_ingroup sample = new hajlist_ingroup(1, "Mohammed Obeid", "40", "icon_man.png", "", "", 1, 0, "Brown");
		    samples = new ObservableCollection<hajlist_ingroup>();
		    samples.Add(sample);
		    sample = new hajlist_ingroup(2, "Momen Obeid", "40", "icon_man.png", "", "", 1, 1, "Green");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(3, "Hasna Obeid", "40", "icon_woman.png", "", "", 1, 0, "Brown");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(4, "Omar Obeid", "40", "icon_man.png", "", "", 1, 0, "Brown");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(5, "Maha Obeid", "40", "icon_woman.png", "", "", 1, 0, "Brown");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(6, "Omar Obeid", "40", "icon_man.png", "", "", 1, 0, "Brown");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(7, "Samia Obeid", "40", "icon_woman.png", "", "", 1, 1, "Green");
		    samples.Add(sample);
             
		    _navigationViewModel = new NavigationViewModel(samples);
		    _navigationViewModel.StatusUpdated += _navigationViewModel_StatusUpdated;
		    HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;

            //HajjListView.ItemsSource = samples.Where(X => X.Status == 0);
		    lblY.Text = "0";
        }
	    private void _navigationViewModel_StatusUpdated()
	    {
	        HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;
	        var StatusT = _navigationViewModel.ListOfHajj.Where(x => x.Status == 1).AsEnumerable();
	        var StatusF = _navigationViewModel.ListOfHajj.Where(x => x.Status == 0).AsEnumerable();
            lblG.Text = StatusT.Count().ToString();
	        lblR.Text = StatusF.Count().ToString();
 	    }

    }
}