using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fiszki.Data;

namespace Fiszki
{
    public partial class MainPage : ContentPage
    {

        BrowseFiszkaPage bfp;

        public MainPage()
        {
            InitializeComponent();
            GetExamples();
        }



        private async void OnAddFiszkaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddFiszkaPage));

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private async void OnBrowseFiszkaClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(BrowseFiszkaPage));
        }
        private async void OnLearnClicked(object sender, EventArgs e)
        {
            if (Data.FiszkaDeck.AllDecks.Count == 0)
            {
                await DisplayAlert(
                    "Brak fiszek!",
                    "Aby móc się uczyć dodaj napierw jakieś fiszki.",
                    "Ok"
                    );
            }
            else
            {
                await Shell.Current.GoToAsync(nameof(LearnSetupPage));
            }
        }

        private async void OnTestClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(Test));
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

            FiszkaDeck.AddDeck("travail");
            FiszkaDeck Travail = FiszkaDeck.AllDecks[0];
            Travail.AddFiszka(new Fiszka("une entreprise", "firma"));
            Travail.AddFiszka(new Fiszka("une société", "firma"));
            Travail.AddFiszka(new Fiszka("un(e) employé(e)", "pracownik"));
            Travail.AddFiszka(new Fiszka("un patron, une patronne", "szef, szefowa"));
            Travail.AddFiszka(new Fiszka("un(e) société", "firma"));
            Travail.AddFiszka(new Fiszka("collègue (de travail)", "kolega z pracy"));
            Travail.AddFiszka(new Fiszka("un(e) client(e)", "klient(ka)"));
            Travail.AddFiszka(new Fiszka("un(e) stagiaire", "stażysta (-tka)"));
            Travail.AddFiszka(new Fiszka("faire un stage", "być na stażu"));
            Travail.AddFiszka(new Fiszka("un rendez-vous", "spotkanie"));
            Travail.AddFiszka(new Fiszka("une réunion", "zebranie"));
            Travail.AddFiszka(new Fiszka("chercher un/du travail", "szukać pracy"));
            Travail.AddFiszka(new Fiszka("postuler pour un poste", "ubiegać się o stanowisko"));
            Travail.AddFiszka(new Fiszka("déposer sa candidature", "zgłosić swoją kandydature"));
            Travail.AddFiszka(new Fiszka("passer un entretien d'embauche", "przejść rozmowę o pracę"));
            Travail.AddFiszka(new Fiszka("avoir les compétences requises (f.)", "mieć wymagane kompetencje"));
            Travail.AddFiszka(new Fiszka("avoir de l’expérience (f.)", "mieć doświadczenie"));
            Travail.AddFiszka(new Fiszka("embaucher", "zatrudnić kogoś"));
            Travail.AddFiszka(new Fiszka("employer", "zatrudnić kogoś"));
            Travail.AddFiszka(new Fiszka("engager qqn", "zatrudnić kogoś"));
            Travail.AddFiszka(new Fiszka("obtenir / quitter un travail", "dostać / rzucić pracę"));
            Travail.AddFiszka(new Fiszka("signer / résilier un contrat", "podpisać / rozwiązać umowę"));
            Travail.AddFiszka(new Fiszka("un contrat à durée déterminée (CDD)", "umowa na czas określony"));
            Travail.AddFiszka(new Fiszka("un contrat à durée indéterminée (CDI)", "umowa na czas nieokreślony"));
            Travail.AddFiszka(new Fiszka("travailler à temps plein", "pracować na pełen etat"));
            Travail.AddFiszka(new Fiszka("travailler à mi-temps", "pracować na pół etat"));
            Travail.AddFiszka(new Fiszka("travailler en intérim", "wykonywać pracę tymczasową"));
            Travail.AddFiszka(new Fiszka("faire un remplacement", "pracować na zastępstwie"));
            Travail.AddFiszka(new Fiszka("faire des heures (f.) supplémentaires", "brać nadgodziny"));
            Travail.AddFiszka(new Fiszka("être en déplacement professionnel", "być na wyjeździe służbowym"));
            Travail.AddFiszka(new Fiszka("toucher son salaire", "pobierać pensję"));
            Travail.AddFiszka(new Fiszka("obtenir une augmentation de salaire", "dostać podwyżkę"));
            Travail.AddFiszka(new Fiszka("ontenir une promotion", "otrzymać awans"));
            Travail.AddFiszka(new Fiszka("prendre un congé", "wziąć urlop"));
            Travail.AddFiszka(new Fiszka("licencier qqn", "zwolnić kogoś"));
            Travail.AddFiszka(new Fiszka("être licencié(e)", "być zwolnionym"));
            Travail.AddFiszka(new Fiszka("déposer un préavis", "złożyć wypowiedzenie"));
            Travail.AddFiszka(new Fiszka("être au chômage", "być na bezrobociu"));
            Travail.AddFiszka(new Fiszka("prendre sa retraite", "przejść na emeryturę"));

            FiszkaDeck.AddDeck("amour relations");
            FiszkaDeck Amour = FiszkaDeck.AllDecks[0];

            Amour.AddFiszka(new Fiszka("un petit ami", "chłopak"));
            Amour.AddFiszka(new Fiszka("un copain", "chłopak"));
            Amour.AddFiszka(new Fiszka("une petite amie", "dziewczyna"));
            Amour.AddFiszka(new Fiszka("une copine", "dziewczyna"));
            Amour.AddFiszka(new Fiszka("un compagnon", "partner"));
            Amour.AddFiszka(new Fiszka("une compagne", "partnerka"));
            Amour.AddFiszka(new Fiszka("un fiancé", "narzeczony"));
            Amour.AddFiszka(new Fiszka("une fiancée", "narzeczona"));
            Amour.AddFiszka(new Fiszka("un jeune marié", "pan młody"));
            Amour.AddFiszka(new Fiszka("une jeune mariée", "panna młoda"));
            Amour.AddFiszka(new Fiszka("un témoin de mariage", "świadek, świadkowa"));
            Amour.AddFiszka(new Fiszka("être amoureux (-euse) de qqn", "być zakochym(-ą) w kimś"));
            Amour.AddFiszka(new Fiszka("s'aimer", "kochać się, darzyć się miłością"));
            Amour.AddFiszka(new Fiszka("sortir ensemble", "chodzić ze sobą"));
            Amour.AddFiszka(new Fiszka("être en couple avec qqn", "być z kimś w związku"));
            Amour.AddFiszka(new Fiszka("être pacsé(e)", "być w formalnym związku partnerskim"));
            Amour.AddFiszka(new Fiszka("sortir ensemble", "chodzić ze sobą"));
            Amour.AddFiszka(new Fiszka("vivre en concubinage", "żyć w konkubinacie"));
            Amour.AddFiszka(new Fiszka("demander qqn en mariage", "poprosić kogoś o rękę"));
            Amour.AddFiszka(new Fiszka("un garçon d’honneur", "drużba"));
            Amour.AddFiszka(new Fiszka("une demoiselle d’honneur", "druhna"));
            Amour.AddFiszka(new Fiszka("un mari, un époux", "maż, małżonek"));
            Amour.AddFiszka(new Fiszka("une femme, une épouse", "żona, małżonka"));
            Amour.AddFiszka(new Fiszka("des fiançailles (f.)", "zaręczyny"));
            Amour.AddFiszka(new Fiszka("se fiancer", "zaręczyny"));
            Amour.AddFiszka(new Fiszka("un enterrement de vie de garçon", "wieczór kawalerski"));
            Amour.AddFiszka(new Fiszka("un enterrement de vie de jeune fille", "wieczór panienski"));
            Amour.AddFiszka(new Fiszka("un mariage civil", "ślub cywilny"));
            Amour.AddFiszka(new Fiszka("un mariage religieux", "ślub kościelny"));
            Amour.AddFiszka(new Fiszka("être fiancé(e) ", "być zaręczonym (-ą)"));
            Amour.AddFiszka(new Fiszka("une réception de mariage, les noces (f.)", "wesele (x2)"));
            Amour.AddFiszka(new Fiszka("un voyage de noces", "podróż poślubna"));
            Amour.AddFiszka(new Fiszka("tomber amoureux(-euse) de qqn", "zakochać się w kimś"));
            Amour.AddFiszka(new Fiszka("se marier (avec qqn)", "wziąć ślub (z kimś), pobrać się"));
            Amour.AddFiszka(new Fiszka("tromper qqn", "zdradzić kogoś"));
            Amour.AddFiszka(new Fiszka("avoir un amant", "mieć kochanka"));
            Amour.AddFiszka(new Fiszka("avoir une maîtresse", "mieć kochankę"));
            Amour.AddFiszka(new Fiszka("demander le divorce", "wystąpić o rozwód"));
            Amour.AddFiszka(new Fiszka("divorcer (de qqn)", "rozwodzić się z kimś"));

        }

    }

}
