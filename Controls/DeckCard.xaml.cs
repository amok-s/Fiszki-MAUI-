using Fiszki.Data;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;

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

    private void PointerGestureRecognizer_PointerPressed(object sender, PointerEventArgs e)
    {
        if (!UnfoldDeck.IsVisible)
        {
            UnfoldDeck.IsVisible = true;
        }
        else if (UnfoldDeck.IsVisible)
        {
            UnfoldDeck.IsVisible = false;
        }
    }
}