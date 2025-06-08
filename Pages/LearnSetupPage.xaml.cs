

using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Fiszki.Data;

namespace Fiszki;

public partial class LearnSetupPage : ContentPage
{
    public LearnSetupPage()
	{
		InitializeComponent();

		DeckCollectionView.ItemsSource = FiszkaDeck.AllDecks;

    }

    private async void StartSessionButton_Clicked(object sender, EventArgs e)
    {
        
        if (DeckCollectionView.SelectedItems.Count == 0)
		{
            await DisplayAlert(
                      "Brak fiszek do nauki",
                      "Musisz wybrać conajmniej jedną talię!",
                      "Ok");
        }

        else
        {
            ObservableCollection<FiszkaDeck> selectedDecks = new ObservableCollection<FiszkaDeck>();
            foreach (var item in DeckCollectionView.SelectedItems)
            {
                FiszkaDeck deck = item as FiszkaDeck;
                selectedDecks.Add(deck);
            }

            int howManyCards;
            Random r = new Random();



            await Navigation.PushAsync(new NewLearnPage(selectedDecks));
        }

    }
}