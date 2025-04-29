using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
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