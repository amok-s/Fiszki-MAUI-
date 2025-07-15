using Fiszki.Data;

namespace Fiszki.Controls;

public partial class DeckCard : ContentView
{
    public static readonly BindableProperty DeckObjectProperty = BindableProperty.Create(nameof(DeckObject), typeof(FiszkaDeck), typeof(DeckCard), null);
    public FiszkaDeck DeckObject
    {
        get => (FiszkaDeck)GetValue(DeckObjectProperty);
        set => SetValue(DeckObjectProperty, value);
    }


    public DeckCard()
	{
		InitializeComponent();
	}



    //------deck pointer HOVER recognizers-----

    private void DeckBorder_PointerEntered(object sender, PointerEventArgs e)
    {
        ShowMenuOverlay();
        DeckBorder.Scale = 1.02;
        DeckBorder.Stroke = Color.FromArgb("#FFF5F5F5");
    }
    private void DeckBorder_PointerExited(object sender, PointerEventArgs e)
    {
        HideMenuOverlay();
        DeckBorder.Scale = 1.0;
        DeckBorder.Stroke = Color.FromArgb("#cfc517");
    }
    private void DeckBtn_PointerEntered(object sender, PointerEventArgs e)
    {
        Button button = sender as Button;
        button.FadeTo(1, 250);
    }
    private void DeckBtn_PointerExited(object sender, PointerEventArgs e)
    {
        Button button = sender as Button;
        button.FadeTo(0.5, 250);
    }

    //-----deck pointer PRESSED------
    private async void DeckBorder_PointerPressed(object sender, PointerEventArgs e)
    {
        await UnfoldAnimation();
        //UnfoldDeck.IsVisible = UnfoldDeck.IsVisible ? false : true;
    }

    private async void RemoveClicked(object sender, EventArgs e)
    {
        bool answer = await App.Current?.Windows[0]?.Page?.DisplayAlert(
          "Usunąć Talię?",
          "Czy na pewno chcesz usunąć daną z całą jej zawartością?",
          "Tak",
          "Nie");

        if (answer)
        {
            await RemoveAnimation();
            FiszkaDeck.RemoveDeck(DeckObject);
        }
    }

    private async void EditClicked(object sender, EventArgs e)
    {
        string result = await App.Current?.Windows[0]?.Page?.DisplayPromptAsync(
            "Podaj nazwę talii",
            "",
            initialValue: DeckObject.Name,
            maxLength: 30,
            cancel: "Anuluj",
            accept: "Ok");

        if (!String.IsNullOrWhiteSpace(result))
        {
            DeckObject.Name = result;
            var page = Navigation.NavigationStack.LastOrDefault();
            await Shell.Current.GoToAsync(nameof(BrowseFiszkaPage));
            Navigation.RemovePage(page);
        }
    }


    private async Task UnfoldAnimation()
    {
        await DeckBorder.TranslateTo(0, -3.0, 80, Easing.CubicInOut);
        DeckBorder.TranslateTo(0, 0, 100, Easing.CubicOut);
    }

    private async Task RemoveAnimation()
    {
        await DeckBorder.ScaleTo(1.02, 80);
        DeckBorder.FadeTo(0.2, 300);
        await DeckBorder.ScaleTo(0.8, 120);
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


    //----menu overlay-----
    private void ShowMenuOverlay()
    {
        MenuOverlayLayout.IsVisible = true;
        MenuOverlayLayout.FadeTo(1, 350);
    }
    private void HideMenuOverlay()
    {
        MenuOverlayLayout.FadeTo(0, 300);
        MenuOverlayLayout.IsVisible = false;
    }

}