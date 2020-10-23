using PlasmaTracker.Services;
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
    public partial class SignInPage : ContentPage
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private async void EntryButton_ClickedAsync(object sender, EventArgs e)
        {
            ApiServices apiServices = new ApiServices();
            bool response= await apiServices.LoginUser(EntryEmail.Text, EntryPassword.Text);
            if (!response)
            {
                DisplayAlert("Alert", "Wrong Email Adress or Password", "Cancel");
            }
            else
            {
                Navigation.InsertPageBefore(new HomePage(),this);
                await Navigation.PopAsync();
            }
        }

        private async void Tapup_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

     
    }
}