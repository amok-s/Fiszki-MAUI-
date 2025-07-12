using System.Collections.ObjectModel;
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

        //--first, check if there is any deck selected   
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

            //then, it checks if in selected decks there are any cards
            int count = 0;
            foreach (var deck in selectedDecks)
            {
                foreach (var fiszka in deck.Deck)
                {
                    count++;
                }
            }

            if (count == 0)
            {
                await DisplayAlert(
                    "Brak fiszek!",
                    "W talii brakuje fiszek do nauki. Dodaj je!",
                    "Ok"
                    );
            }

            //in the end it creates a new LearnPage
            else
            {
                var lengthSetting = RadioButtonGroup.GetSelectedValue(LearningLengthLayout);
                await Navigation.PushAsync(new LearnPage(lengthSetting.ToString(), selectedDecks));
            }
        }

    }
    
    private void SelectAllButton_Clicked(object sender, EventArgs e)
    {
        foreach (var item in DeckCollectionView.ItemsSource)
        {
            DeckCollectionView.SelectedItems.Add(item);
        }

    }

    private void DeselectAllButton_Clicked(object sender, EventArgs e)
    {
        DeckCollectionView.SelectedItems = null;

    }


}