using System.Threading.Tasks;

namespace Fiszki
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
        }



        private async void OnAddFiszkaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddFiszkaPage));
            //DisplayAlert(
            //    "Dodaj fiszkę",
            //    "Tutaj coś będzie",
            //    "OK");
            


            //DisplayActionSheet(
            //    "",
            //    "Anuluj",
            //    "Dodaj");



            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnBrowseFiszkaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(BrowseFiszkaPage));
            
        }
    }

}
