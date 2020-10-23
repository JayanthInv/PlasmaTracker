using PlasmaTracker.Models;
using PlasmaTracker.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PlasmaTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DonarsListPage : ContentPage
    {
        public ObservableCollection<PlasmaUser> PlasmaUser { get; }
        private string _bloodGroup;
        private String _country;
        public DonarsListPage(string country, string blood)
        {
            InitializeComponent();
            PlasmaUser = new ObservableCollection<PlasmaUser>();
            _bloodGroup = blood;
            _country = country;
            FindBloodDonars();
        }

        private async void FindBloodDonars()
        {
            ApiServices apiServices = new ApiServices();
            var bloodUser = await apiServices.FindBlood(_country, _bloodGroup);
            foreach(var blood in bloodUser)
            {
                PlasmaUser.Add(blood);
            }
            EntryBlood.ItemsSource = PlasmaUser;
        }

        private void EntryBlood_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected=e.SelectedItem as PlasmaUser;
            Navigation.PushAsync(new DonarProfilePage(selected));
        }
    }
}