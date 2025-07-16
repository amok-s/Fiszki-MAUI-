using Fiszki.Data;

namespace Fiszki.Controls;

public partial class DeckInside : ContentView
{
    public static readonly BindableProperty DeckObjectProperty = BindableProperty.Create(nameof(DeckObject), typeof(FiszkaDeck), typeof(DeckCard), null);
    public FiszkaDeck DeckObject
    {
        get => (FiszkaDeck)GetValue(DeckObjectProperty);
        set => SetValue(DeckObjectProperty, value);
    }

    public DeckInside(FiszkaDeck deck)
    {
        DeckObject = deck;
        InitializeComponent();
    }
}