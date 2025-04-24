namespace Fiszki;

public partial class AddFiszkaPage : ContentPage
{
    string? nativeString;
    string? translatedString;

	public AddFiszkaPage()
	{
		InitializeComponent();
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
                Fiszka.fiszkaDeck.Add(p);
                await DisplayAlert(
                    "Fiszka dodana!",
                    p.nativePhrase + "  /  " + p.translatedPhrase,
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