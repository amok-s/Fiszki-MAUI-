

using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Fiszki.Data;

namespace Fiszki;

public partial class LearnSetupPage : ContentPage
{
    public static ObservableCollection<FiszkaDeck> selectedDecks;

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
            FiszkaDeck g = DeckCollectionView.SelectedItems[0] as FiszkaDeck;

            await DisplayAlert(
                      "Brak fiszek do nauki",
                      g.Name,
                      "Ok");
        }




        int howManyCards;
		Random r = new Random();
		

    }
}