using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlasmaTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.InsertPageBefore(new SignInPage(), this);
            Navigation.PopAsync();

        }

        private void TapFindBlood_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FindBloodGroup());
        }

        private void TapRegister_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }

        private void TapLatest_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LatestDonars());
        }

        private void TapHelp_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HelpPage());
        }
    }
}