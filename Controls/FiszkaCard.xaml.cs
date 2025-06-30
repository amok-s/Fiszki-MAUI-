using System.Collections.ObjectModel;
using Fiszki.Data;

namespace Fiszki.Controls;

public partial class FiszkaCard : ContentView
{

    //-----bindable properties-------
	public static readonly BindableProperty FiszkaObjectProperty = BindableProperty.Create(nameof(FiszkaObject), typeof(Fiszka), typeof(FiszkaCard), null);
	public Fiszka FiszkaObject
    {
        get => (Fiszka)GetValue(FiszkaObjectProperty);
        set => SetValue(FiszkaObjectProperty, value);
    }

    public static readonly BindableProperty UpperBarIsVisibleProperty = BindableProperty.Create(nameof(UpperBarIsVisible), typeof(bool), typeof(FiszkaCard), null);
    public bool UpperBarIsVisible
    {
        get => (bool)GetValue(UpperBarIsVisibleProperty);
        set => SetValue(UpperBarIsVisibleProperty, value);
    }



    public bool IsEditable = true;



    public FiszkaCard()
	{
		InitializeComponent();
    }


    //-----Menu overlay buttons------
    private async void RemoveClicked(object sender, EventArgs e)
    {
        bool answer = await App.Current?.Windows[0]?.Page?.DisplayAlert(
            "Usunąć Fiszkę?",
            "Czy na pewno chcesz usunąć daną fiszkę?",
            "Tak",
            "Nie");

        if (answer)
        {
            await RemoveAnimation();
            var decknames = FiszkaObject.DecksIsIn.ToList();
            foreach (var deckname in decknames)
            {
                foreach (var deck in FiszkaDeck.AllDecks)
                {
                    if (deck.Name == deckname)
                    {
                        deck.RemoveFiszka(FiszkaObject);
                    }
                }
            }
        }
        
    }
    private async void EditClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddFiszkaPage(null, FiszkaObject));
    }



    private async Task RemoveAnimation()
    {
        await Fiszka.ScaleTo(1.02, 80);
        Fiszka.FadeTo(0.2, 300);
        await Fiszka.ScaleTo(0.8, 120);
    }

    //----Button(in overlay menu) Pointer Recognizers---->
    private void FiszkaBtn_PointerEntered(object sender, PointerEventArgs e)
    {
        Button button = sender as Button;
        button.FadeTo(1, 250);
    }
    private void FiszkaBtn_PointerExited(object sender, PointerEventArgs e)
    {
        Button button = sender as Button;
        button.FadeTo(0.5, 250);
    }


    //---- Fiszka Card Pointer Recognizers---->
    private async void FiszkaCard_PointerEntered(object sender, PointerEventArgs e)
    {
        if (IsEditable)
        {
            MenuOverlayLayout.IsVisible = true;
            MenuOverlayLayout.FadeTo(1, 350);
        }
        FiszkaBorder.Stroke = Color.Parse("White");
    }
    private async void FiszkaCard_PointerExited(object sender, PointerEventArgs e)
    {
        FiszkaBorder.Stroke = Color.FromArgb("#cfc517");
        MenuOverlayLayout.FadeTo(0, 300);
        MenuOverlayLayout.IsVisible = false;
    }


}