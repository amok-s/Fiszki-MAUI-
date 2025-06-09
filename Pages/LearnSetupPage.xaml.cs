

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


            var lengthSetting = RadioButtonGroup.GetSelectedValue(LearningLengthLayout);

            await Navigation.PushAsync(new NewLearnPage(lengthSetting.ToString(),selectedDecks));
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