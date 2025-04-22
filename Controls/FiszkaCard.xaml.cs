using System.Collections.ObjectModel;

namespace Fiszki.Controls;

public partial class FiszkaCard : ContentView
{
	public static readonly BindableProperty FiszkaDeckProperty = BindableProperty.Create(nameof(FiszkaDeck), typeof(ObservableCollection<Fiszka>), typeof(FiszkaCard), null);

	public ObservableCollection<Fiszka> FiszkaDeck
	{ 
		get => (ObservableCollection<Fiszka>)GetValue(FiszkaDeckProperty);
		set => SetValue(FiszkaDeckProperty, value);
	}

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

    private void RemoveClicked(object sender, EventArgs e)
    {
		
		FiszkaObject.RemoveFiszka();
    }
}