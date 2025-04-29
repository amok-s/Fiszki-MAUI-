using System.Collections.ObjectModel;
using Fiszki.Data;

namespace Fiszki.Controls;

public partial class FiszkaCard : ContentView
{

	public static readonly BindableProperty FiszkaObjectProperty = BindableProperty.Create(nameof(FiszkaObject), typeof(Fiszka), typeof(FiszkaCard), null);
	public Fiszka FiszkaObject
	{
		get => (Fiszka)GetValue(FiszkaObjectProperty);
		set => SetValue(FiszkaObjectProperty, value);
    }
	public FiszkaCard()
	{
		InitializeComponent();
    }

    private async void RemoveClicked(object sender, EventArgs e)
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

    private async Task RemoveAnimation()
    {
        Fiszka.FadeTo(0.2, 300);
        await Fiszka.ScaleTo(0.8, 120);
    }

    private void FiszkaEditBtn_PointerEntered(object sender, PointerEventArgs e)
    {
        FiszkaEditBtn.TextColor = Color.FromArgb("#96B639");
    }

    private void FiszkaEditBtn_PointerExited(object sender, PointerEventArgs e)
    {
        FiszkaEditBtn.TextColor = Color.FromArgb("#FFF5F5F5");
    }
}