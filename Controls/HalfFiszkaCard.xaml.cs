using Fiszki.Data;

namespace Fiszki.Controls;

public partial class HalfFiszkaCard : ContentView
{

	public static readonly BindableProperty FiszkaObjectProperty = BindableProperty.Create(nameof(FiszkaObject), typeof(Fiszka), typeof(FiszkaCard), null);
	public Fiszka FiszkaObject
	{
		get => (Fiszka)GetValue(FiszkaObjectProperty);
		set => SetValue(FiszkaObjectProperty, value);
    }
	public HalfFiszkaCard()
	{
		InitializeComponent();
		ShowRandomPhrase();

    }

	public void ShowRandomPhrase()
	{
		var r = new Random();
		int n = r.Next(1, 3);
		if (n == 1)
		{	
			NativePhraseLabel.IsVisible = false;
			TranslatedPhraseLabel.IsVisible = true;

		}
		else
		{
            TranslatedPhraseLabel.IsVisible = false;
			NativePhraseLabel.IsVisible = true;
		}
	}

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
        FiszkaBorder.Stroke = Color.Parse("White");
    }

    private void PointerGestureRecognizer_PointerExited(object sender, PointerEventArgs e)
    {
        FiszkaBorder.Stroke = Color.FromArgb("#cfc517");
    }
}