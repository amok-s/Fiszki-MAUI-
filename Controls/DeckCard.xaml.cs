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

    private async void DeckBorder_PointerPressed(object sender, PointerEventArgs e)
    {
        await UnfoldAnimation();
        UnfoldDeck.IsVisible = UnfoldDeck.IsVisible ? false : true;
    }

    private void DeckBorder_PointerEntered(object sender, PointerEventArgs e)
    {
        DeckBorder.Stroke = Color.FromArgb("#FFF5F5F5");
    }

    private void DeckBorder_PointerExited(object sender, PointerEventArgs e)
    {
        DeckBorder.Stroke = Color.FromArgb("#cfc517");
    }

    private async Task UnfoldAnimation()
    {
        await DeckBorder.TranslateTo(0, -3.0, 80, Easing.CubicInOut);
        DeckBorder.TranslateTo(0, 0, 100, Easing.CubicOut);
    }

}