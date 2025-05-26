using System.ComponentModel;
using Fiszki.Controls;
using Fiszki.Data;

namespace Fiszki;

public partial class AddFiszkaPage : ContentPage
{
    FiszkaDeck? currentDeck;
    string? nativeString;
    string? translatedString;
    Fiszka? editFiszka;
   

    public AddFiszkaPage(FiszkaDeck deck = null, Fiszka editingFiszka = null)
    {
        InitializeComponent();


        //----Adding new Fiszka---->
        if (deck != null )
        {
            currentDeck = deck;
        }

        //----Editing existing Fiszka----->
        if (editingFiszka != null )
        {
            var firstDeckName = editingFiszka.DecksIsIn[0];
            FiszkaDeck firstDeck = null;

            foreach (FiszkaDeck item in FiszkaDeck.AllDecks)
            {
                if (item.Name == firstDeckName)
                {
                    currentDeck = item;
                }
            }

            MainLabel.Text = "edycja fiszki";
            NativeTextEntry.Text = editingFiszka.NativePhrase;
            TranslatedTextEntry.Text = editingFiszka.TranslatedPhrase;
            editFiszka = editingFiszka;
            addFiszkaBtn.Text = "Akceptuj";
        }




        DeckNameLabel.Text = currentDeck.Name;


    }




    private static bool CheckStrings(string a, string b)
    {
        if (String.IsNullOrWhiteSpace(a) || String.IsNullOrWhiteSpace(b))
        {
            return false;
        }
        else return true;

    }

    private async void OnAddFiszkaClicked(object sender, EventArgs e)
    {
        nativeString = NativeTextEntry.Text;
        translatedString = TranslatedTextEntry.Text;

        bool StringsNotEmpty = CheckStrings(nativeString, translatedString);

        if (StringsNotEmpty)
        {
            try
            {

                //-----Editing fiszka----->
                if (editFiszka != null)
                {
                    editFiszka.TranslatedPhrase = translatedString;
                    editFiszka.NativePhrase = nativeString;
                    await DisplayAlert(
                       "Fiszka zmieniona!",
                       editFiszka.NativePhrase + "  /  " + editFiszka.TranslatedPhrase,
                       "Ok");
                    Shell.Current.GoToAsync(nameof(BrowseFiszkaPage));
                    Navigation.RemovePage(this);
                }

                //-----New fiszka------>
                else
                {
                    var p = new Fiszka(nativeString, translatedString);
                    currentDeck.AddFiszka(p);
                    await DisplayAlert(
                        "Fiszka dodana!",
                        p.NativePhrase + "  /  " + p.TranslatedPhrase,
                        "Ok");
                    RefreshPage();
                }

             



            }

            catch (Exception ex) 
            {
                await DisplayAlert(
                    "Wystąpił błąd!",
                    ex.Message,
                    "Ok");
                Console.WriteLine(ex.ToString());
            }
        }
        else
        {
            await DisplayAlert(
                "",
                "Fiszka nie może być pusta!",
                "Ok");
        }

    }
    private void RefreshPage()
    {
        NativeTextEntry.Text = null;
        TranslatedTextEntry.Text = null;
        NativeTextEntry.Focus();



    }

}