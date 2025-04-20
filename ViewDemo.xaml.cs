namespace Fiszki;

public partial class ViewDemo : ContentView
{

	public static readonly BindableProperty FiszkaObjectProperty = BindableProperty.Create(nameof(FiszkaObject), typeof(Fiszka), typeof(ViewDemo), null);
	public Fiszka FiszkaObject
	{
		get => (Fiszka)GetValue(FiszkaObjectProperty);
		set => SetValue(FiszkaObjectProperty, value);
    }
	public ViewDemo()
	{
		InitializeComponent();
    }
}