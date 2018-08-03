using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AFWAJ.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeDetail : ContentPage
    {
        public HomeDetail()
        {
            InitializeComponent();
        }
        private void LogUser()
        {
            Navigation.PushAsync(new UserTasks(), true);
          //  Navigation.PushAsync(new Profile(), true);

        }
    }
}