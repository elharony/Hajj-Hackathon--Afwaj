using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
	public partial class GroupTracking : ContentPage
	{
	    private GroupTrackingViewModel _model = new GroupTrackingViewModel();
	    private NavigationViewModel _navigationViewModel;

        public GroupTracking ()
		{
			InitializeComponent ();
            //_model.LoadDone += ModelOnLoadDone;
		    hajlist_ingroup sample =  new hajlist_ingroup(1,"Mohammed Obeid","40", "icon_man.png", "","",1,0,"Red");
		    ObservableCollection<hajlist_ingroup> samples = new ObservableCollection<hajlist_ingroup>();
            samples.Add(sample);
		    sample = new hajlist_ingroup(2, "Momen Obeid", "40", "icon_man.png", "", "", 1, 1, "Red");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(3, "Hasna Obeid", "40", "icon_woman.png", "", "", 1, 0, "Red");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(4, "Omar Obeid", "40", "icon_man.png", "", "", 1, 0, "Red");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(5, "Maha Obeid", "40", "icon_woman.png", "", "", 1, 0, "Red");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(6, "Omar Obeid", "40", "icon_man.png", "", "", 1, 0, "Red");
		    samples.Add(sample);
		    sample = new hajlist_ingroup(7, "Samia Obeid", "40", "icon_woman.png", "", "", 1, 1, "Red");
		    samples.Add(sample);

            _model.ListOfHajj = samples;
            _navigationViewModel = new NavigationViewModel(_model.ListOfHajj);
            _navigationViewModel.StatusUpdated += _navigationViewModel_StatusUpdated;
		    HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;
		    BindingContext = _navigationViewModel;

        }

        private void _navigationViewModel_StatusUpdated()
        {
            HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;
            var StatusT = _navigationViewModel.ListOfHajj.Where(x => x.Status == 1).AsEnumerable();
            var StatusF = _navigationViewModel.ListOfHajj.Where(x => x.Status == 0).AsEnumerable();
            lbltotla.Text = StatusT.Count().ToString();
            lblmissing.Text = StatusF.Count().ToString();
            _navigationViewModel.StopTracking();
        }

        private void ModelOnLoadDone()
	    {
	        _navigationViewModel = new NavigationViewModel(_model.ListOfHajj);

	        BindingContext = _navigationViewModel;


        }

        private  void NavigationViewModelOnStatusUpdated()
        {
	      
        }

        private void BtnStart_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new TripView());
	    }

	    private void HajjListView_ItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        Navigation.PushAsync(new Profile());
        }
	}
}