namespace Fiszki.Controls;

public partial class AddFiszka : ContentView
{

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
        await Shell.Current.GoToAsync(nameof(AddFiszkaPage));
    }

    private void ChangeBorderStyle(string styleName)
    {
        var hasStyle = Resources.TryGetValue(styleName, out object style);
        DeckBorder.Style = (Style)style;
    }
}