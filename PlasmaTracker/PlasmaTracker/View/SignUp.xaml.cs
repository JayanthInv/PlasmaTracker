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
    public partial class SignUp : ContentPage
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private async void EntrySignupButton_Clicked(object sender, EventArgs e)
        {
            PlasmaTracker.Services.ApiServices apiServices = new Services.ApiServices();
            bool response = await apiServices.RegisterUserAsync(EntryEmail.Text, EntryPassword.Text, EntryConnformPassword.Text);
            if (!response)
            {
                await DisplayAlert("Alert", "There is some problem while creating your account", "Cancel");
            }
            else
            {
                await DisplayAlert("Hello", "Successfully Created", "Ok");
                await Navigation.PopToRootAsync();
            }
        }
        
    }
}