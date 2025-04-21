namespace Fiszki;

public partial class AddFiszkaPage : ContentPage
{
	public AddFiszkaPage()
	{
		InitializeComponent();
	}

    
    private void OnAddFiszkaClicked(object sender, EventArgs e)
    {
        string nativeString = NativeTextEntry.Text;
        string translatedString = TranslatedTextEntry.Text;


        try
        {
            var p = new Fiszka(nativeString, translatedString);
            Fiszka.fiszkaDeck.Add(p);
            DisplayAlert(
                "Fiszka dodana!",
                p.nativePhrase + "  /  " + p.translatedPhrase,
                "Ok");
            

        }
        catch (Exception ex) 
        {
            DisplayAlert(
                "Wystąpił błąd!",
                ex.Message,
                "Ok");
            Console.WriteLine(ex.ToString());
        }

       

		

    }
}