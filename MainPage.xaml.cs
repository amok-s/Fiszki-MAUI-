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
            await Shell.Current.GoToAsync(nameof(LearnSetupPage));
        }

        public void GetExamples()
        {
            FiszkaDeck.AddDeck("les animaux");
            FiszkaDeck AnimalDeck = FiszkaDeck.AllDecks[0];

            AnimalDeck.AddFiszka(new Fiszka("un chat", "kot"));
            AnimalDeck.AddFiszka(new Fiszka("un chien", "pies"));
            AnimalDeck.AddFiszka(new Fiszka("un lapin", "królik"));
            AnimalDeck.AddFiszka(new Fiszka("une tortue", "żółw"));
            AnimalDeck.AddFiszka(new Fiszka("un poisson", "ryba"));
            AnimalDeck.AddFiszka(new Fiszka("une souris", "mysz"));
            AnimalDeck.AddFiszka(new Fiszka("une vache", "krowa"));
            AnimalDeck.AddFiszka(new Fiszka("un renard", "lis"));


            FiszkaDeck.AddDeck("verbes utiles");
            FiszkaDeck Verbs = FiszkaDeck.AllDecks[0];

            Verbs.AddFiszka(new Fiszka("être", "być"));
            Verbs.AddFiszka(new Fiszka("avoir", "mieć"));
            Verbs.AddFiszka(new Fiszka("faire", "robić"));
            Verbs.AddFiszka(new Fiszka("dire", "mówić"));
            Verbs.AddFiszka(new Fiszka("venir", "przychodzić, przyjeżdżać"));
            Verbs.AddFiszka(new Fiszka("manger", "jeść"));

            FiszkaDeck.AddDeck("périodes de la vie");
            FiszkaDeck Periodes = FiszkaDeck.AllDecks[0];
            Periodes.AddFiszka(new Fiszka("un nouveau-né", "noworodek"));
            Periodes.AddFiszka(new Fiszka("un bébé", "niemowlę"));
            Periodes.AddFiszka(new Fiszka("un(e) enfant", "dziecko"));
            Periodes.AddFiszka(new Fiszka("un(e) adolescent(e)", "nastolatek (-tka)"));
            Periodes.AddFiszka(new Fiszka("un(e) adulte", "osoba dorosła"));
            Periodes.AddFiszka(new Fiszka("un jeune homme", "młody dorosły"));
            Periodes.AddFiszka(new Fiszka("une jeune femme", "młoda kobieta"));
            Periodes.AddFiszka(new Fiszka("une personne âgée", "osoba starsza"));
            Periodes.AddFiszka(new Fiszka("une enfance", "dzieciństwo"));
            Periodes.AddFiszka(new Fiszka("une adolescence", "wiek nastoletni, okres dojrzewania"));
            Periodes.AddFiszka(new Fiszka("une jeunesse", "młodość"));
            Periodes.AddFiszka(new Fiszka("une vieillesse", "starość"));
            Periodes.AddFiszka(new Fiszka("grandir", "dorastać"));
            Periodes.AddFiszka(new Fiszka("vieillir", "starzeć się"));
            Periodes.AddFiszka(new Fiszka("avoir ... an(s)", "mieć ... lat"));
            Periodes.AddFiszka(new Fiszka("être mineur(e)", "być niepełnoletnim"));
            Periodes.AddFiszka(new Fiszka("être majeur(e)", "być pełnoletnim"));
            Periodes.AddFiszka(new Fiszka("fêter son anniversaire", "obchodzić / świętować urodziny"));
            Periodes.AddFiszka(new Fiszka("élever un enfant", "wychowywać dziecko"));
            Periodes.AddFiszka(new Fiszka("gâter un enfant ", "rozpieszczać dziecko"));

        }

    }

}
