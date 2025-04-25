using System.Collections.ObjectModel;
using Fiszki.Data;

namespace Fiszki;

public partial class BrowseFiszkaPage : ContentPage
{
	FiszkaDeck? currentDeck;

	public BrowseFiszkaPage()
	{
		InitializeComponent();
        //currentDeck = FiszkaDeck.AllDecks[0];
        //      collectionView.ItemsSource = currentDeck.Deck;
        collectionView.ItemsSource = GetAllCheckedDecks();
    }

    public ObservableCollection<Fiszka> GetAllCheckedDecks()
    {
        var browseDeck = new ObservableCollection<Fiszka>();
        foreach(var deck in FiszkaDeck.AllDecks)
        {
            if (deck.IsChecked == true)
            {
                foreach (var fiszka in deck.Deck)
                {
                    browseDeck.Add(fiszka);
                }
            }
        }
        return browseDeck;
    }
}