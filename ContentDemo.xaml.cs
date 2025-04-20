namespace Fiszki;

public partial class ContentDemo : ContentPage
{
	public ContentDemo()
	{
		InitializeComponent();
		collectionView.ItemsSource = GetDeck();
	}

	private List<Fiszka> GetDeck()
	{
		return new List<Fiszka>
		{
			new ("la maison", "dom"),
			new Fiszka("le chat", "kot"),
			new Fiszka("le chien", "pies"),
			new Fiszka("l'homme", "chłopak"),
			new Fiszka("l'eau", "woda"),
			new Fiszka("le doigt", "palec"),
			new ("sac à dos", "plecak")

        };  
	}
}