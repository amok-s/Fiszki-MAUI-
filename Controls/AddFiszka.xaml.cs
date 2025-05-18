namespace Fiszki.Controls;

public partial class AddFiszka : ContentView
{

    public static readonly BindableProperty DeckObjectProperty = BindableProperty.Create(nameof(DeckObject), typeof(Data.FiszkaDeck), typeof(DeckCard), null);
    public Data.FiszkaDeck DeckObject
    {
        get => (Data.FiszkaDeck)GetValue(DeckObjectProperty);
        set => SetValue(DeckObjectProperty, value);
    }


    public AddFiszka()
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
        await Navigation.PushAsync(new AddFiszkaPage(DeckObject));
    }

    private void ChangeBorderStyle(string styleName)
    {
        var hasStyle = Resources.TryGetValue(styleName, out object style);
        DeckBorder.Style = (Style)style;
    }
}