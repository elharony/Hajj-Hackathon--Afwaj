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
	public partial class UserTasks : ContentPage
	{
	    //UserTasksViewModel model = new UserTasksViewModel();

        public UserTasks ()
		{
			InitializeComponent ();
		  //  BindingContext = model;
		 //   model.LoadDone += delegate
		    //{
		    //  //  TasksListView.ItemsSource = model.UserRoutes;
      //      };

		}
    	  

	    //private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
	    //{
	    //    Navigation.PushAsync(new GroupTracking());
	    //}

	    private void OnListViewItemTapped(object sender, ItemTappedEventArgs e)
	    {
	        Navigation.PushAsync(new GroupTracking());
	    }

	    private void Btnpass_OnClicked(object sender, EventArgs e)
	    {
	        Navigation.PushAsync(new GroupTracking());
	    }
    }
}