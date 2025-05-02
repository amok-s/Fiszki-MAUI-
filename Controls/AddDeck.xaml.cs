using Fiszki.Data;
using Fiszki.Pages;

namespace Fiszki.Controls;

public partial class AddDeck : ContentView
{
	public AddDeck()
	{
		InitializeComponent();
	}

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        ChangeBorderStyle("BorderOnHover");
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        ChangeBorderStyle("BorderNormal");
    }

    private async void PointerGestureRecognizer_PointerPressed(object sender, PointerEventArgs e)
    {
        ChangeBorderStyle("BorderNormal");
        DisplayNewDeckPrompt();
        //await Shell.Current.GoToAsync(nameof(AddDeckPage));
    }
    private void ChangeBorderStyle(string styleName)
    {
        var hasStyle = Resources.TryGetValue(styleName, out object style);
        DeckBorder.Style = (Style)style;
    }

    private async void DisplayNewDeckPrompt()
    {
        string result = await App.Current?.Windows[0]?.Page?.DisplayPromptAsync(
            "Podaj nazwę talii",
            "",
            initialValue: "Nowa talia",
            maxLength: 30,
            cancel: "Anuluj",
            accept: "Ok");

        if (!String.IsNullOrWhiteSpace(result))
        {
            FiszkaDeck.AddDeck(result);
        }
        
    }
}