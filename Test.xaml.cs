using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using Fiszki.Data;

namespace Fiszki;

public partial class Test : ContentPage
{
	public FiszkaDeck? currentDeck;
    public static List<string>? cards;


    public Test()
	{
        InitializeComponent();
        DeckCollectionView.ItemsSource = FiszkaDeck.AllDecks;
        //currentDeck = FiszkaDeck.AllDecks[0];
        //      collectionView.ItemsSource = currentDeck.Deck;
        GetNames();
        
       
      
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

    public static void GetNames()
    {
        var list = new List<string>();
        foreach(var deck in FiszkaDeck.AllDecks)
        {
            list.Add(deck.Name);
        }
        cards = list;
    }
}