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


    public DeckInside()
	{
		InitializeComponent();
        //DeckObject = deck;
    }

    public DeckInside(FiszkaDeck deck)
    {
        DeckObject = deck;
        InitializeComponent();
        Log();
    }

    private async void Log()
    {
        await App.Current?.Windows[0]?.Page?.DisplayAlert(
          "Usunąć Talię?",
          DeckObject.Name,
          "Tak");
    }
}