using Fiszki.Data;

namespace Fiszki;

public partial class BrowseFiszkaPage : ContentPage
{

    public BrowseFiszkaPage()
	{
        InitializeComponent();
        BindableLayout.SetItemsSource(DeckCollectionView, FiszkaDeck.AllDecks);
    }

}

