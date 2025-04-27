using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fiszki.Data;

namespace Fiszki
{
    public partial class MainPage : ContentPage
    {
        

        public MainPage()
        {
            InitializeComponent();
            GetExamples();
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
        private async void OnLearnClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(LearnPage));
        }

        private async void OnTestClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Test));
        }

        public void GetExamples()
        {
            FiszkaDeck AnimalDeck = new FiszkaDeck("les animaux");

            AnimalDeck.AddFiszka(new Fiszka("un chat", "kot"));
            AnimalDeck.AddFiszka(new Fiszka("un chat", "kot"));
            AnimalDeck.AddFiszka(new Fiszka("un chien", "pies"));
            AnimalDeck.AddFiszka(new Fiszka("un lapin", "królik"));
            AnimalDeck.AddFiszka(new Fiszka("une tortue", "żółw"));
            AnimalDeck.AddFiszka(new Fiszka("un poisson", "ryba"));
            AnimalDeck.AddFiszka(new Fiszka("une souris", "mysz"));
            AnimalDeck.AddFiszka(new Fiszka("une vache", "krowa"));
            AnimalDeck.AddFiszka(new Fiszka("un renard", "lis"));

            FiszkaDeck Verbs = new FiszkaDeck("verbes utiles");

            Verbs.AddFiszka(new Fiszka("être", "być"));
            Verbs.AddFiszka(new Fiszka("avoir", "mieć"));
            Verbs.AddFiszka(new Fiszka("faire", "robić"));
            Verbs.AddFiszka(new Fiszka("dire", "mówić"));
            Verbs.AddFiszka(new Fiszka("venir", "przychodzić, przyjeżdżać"));
            Verbs.AddFiszka(new Fiszka("manger", "jeść"));

            AnimalDeck.IsChecked = true;
            Verbs.IsChecked = true;
        }

    }

}
