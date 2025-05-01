namespace Fiszki.Controls;

public partial class AddFiszka : ContentView
{
	public AddFiszka()
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

    private async void PointerGestureRecognizer_PointerPressed(object sender, PointerEventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(AddFiszkaPage));
    }
}