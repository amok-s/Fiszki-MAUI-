using Fiszki.Data;

namespace Fiszki;

public partial class AddFiszkaPage : ContentPage
{
    FiszkaDeck? currentDeck;
    string? nativeString;
    string? translatedString;

    public AddFiszkaPage()
    {
        InitializeComponent();
        currentDeck = FiszkaDeck.AllDecks[0];
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
                var p = new Fiszka(nativeString, translatedString);
                currentDeck.AddFiszka(p);
                await DisplayAlert(
                    "Fiszka dodana!",
                    p.NativePhrase + "  /  " + p.TranslatedPhrase,
                    "Ok");
                RefreshPage();
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