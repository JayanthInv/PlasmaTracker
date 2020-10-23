using PlasmaTracker.Models;
using Plugin.Messaging;
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
    public partial class DonarProfilePage : ContentPage
    {
        private string _email;
        private string _phoneNumber;

        public DonarProfilePage()
        {
        }

        public DonarProfilePage(PlasmaUser plasmaUser)
        {
            InitializeComponent();
            LabelName.Text = plasmaUser.Username;
            LBloodG.Text = plasmaUser.BloodGroup;
            LCountry.Text = plasmaUser.Location;
            _email = plasmaUser.Email;
            _phoneNumber = plasmaUser.Phone;
        }

        private void TapEmail_Tapped(object sender, EventArgs e)
        {
            var emailMessenger = CrossMessaging.Current.EmailMessenger;
            if (emailMessenger.CanSendEmail)
            {
                // Send simple e-mail to single receiver without attachments, bcc, cc etc.
                emailMessenger.SendEmail(_email, "Subject", "EmailBody");

            }
        }

            private void TapPhone_Tapped(object sender, EventArgs e)
        {
            var phoneDialer = CrossMessaging.Current.PhoneDialer;
            if (phoneDialer.CanMakePhoneCall)
                phoneDialer.MakePhoneCall(_phoneNumber);
        }
    }
}