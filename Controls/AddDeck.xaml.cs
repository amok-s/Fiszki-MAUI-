namespace Fiszki.Controls;

public partial class AddDeck : ContentView
{
	public AddDeck()
	{
		InitializeComponent();
	}

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        var hasStyle = Resources.TryGetValue("BorderOnHover", out object style);
        DeckBorder.Style = (Style)style;
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        var hasStyle = Resources.TryGetValue("BorderNormal", out object style);
        DeckBorder.Style = (Style)style;
    }
}