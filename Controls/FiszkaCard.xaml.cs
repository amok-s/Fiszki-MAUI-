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

		var command = new Command(() => FiszkaObject.RemoveFiszka());
    }

    private void FiszkaEditBtn_Clicked(object sender, EventArgs e)
    {
		
		FiszkaObject.RemoveFiszka();
    }
}