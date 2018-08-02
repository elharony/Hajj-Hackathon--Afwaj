using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
		    _model.LoadDone += ModelOnLoadDone;

        }

        private void ModelOnLoadDone()
	    {
	        _navigationViewModel = new NavigationViewModel(_model.ListOfHajj);
	        _navigationViewModel.StatusUpdated += NavigationViewModelOnStatusUpdated;
	        HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;
	        BindingContext = _navigationViewModel;


        }

        private void NavigationViewModelOnStatusUpdated()
	    {
	        HajjListView.ItemsSource = _navigationViewModel.ListOfHajj;

	    }
	}
}