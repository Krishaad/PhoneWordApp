//using Android.Telephony;

namespace PhoneWord
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        string translatedNum;

        private void OnTranslate(object sender, EventArgs e)
        {
            string enteredNum = PhoneNumberText.Text;
            translatedNum = PhoneWord.PhonewordTranslator.ToNumber(enteredNum);
            if (!string.IsNullOrEmpty(translatedNum))
            {
                CallButton.IsEnabled = true;
                CallButton.Text = "Call " + translatedNum;
            }
            else
            {
                CallButton.IsEnabled = false;
                CallButton.Text = "Call";
            }
        }
        async void OnCall(object sender, System.EventArgs e)
        {
            if (await this.DisplayAlert(
                "Dial a Number",
                "Would you like to call " + translatedNum + "?",
                "Yes",
                "No"))
            {
                try
                {
                    if (PhoneDialer.Default.IsSupported)
                        PhoneDialer.Default.Open(translatedNum);
                }
                catch (ArgumentNullException)
                {
                    await DisplayAlert("Unable to dial", "Phone number was not valid.", "OK");
                }
                catch (Exception)
                {
                    // Other error has occurred.
                    await DisplayAlert("Unable to dial", "Phone dialing failed.", "OK");
                }
            }
        }
    }

}
