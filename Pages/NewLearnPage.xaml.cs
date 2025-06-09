using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Fiszki.Data;

namespace Fiszki;

public partial class NewLearnPage : ContentPage
{   
	
    public static ObservableCollection<FiszkaDeck> selectedDecks;
	ObservableCollection<Fiszka> mixedDecks = new ObservableCollection<Fiszka>();
    ObservableCollection<Fiszka> learningDeck = new ObservableCollection<Fiszka>();
    string chosenSetting;

    int previous_n;
	int count = 0;
	int countGoal;

	double sessionScore = 0;

	Fiszka? currentFiszka;
	
	
	public NewLearnPage(string lengthSetting, ObservableCollection<FiszkaDeck> decks)
	{
		InitializeComponent();

        selectedDecks = decks;
		chosenSetting = lengthSetting;

        ChosenSettingLabel.Text = "Wybrana długość: " + chosenSetting;

        fullFiszkaControl.IsEditable = false;
        fullFiszkaControl.IsVisible = false;
        ScoreButtons.IsVisible = false;

        MixDecks();
		SetLearningLength(lengthSetting);
		LearningDeckCount.Text = count + " / " + countGoal;

        if (CheckIfNotEmpty())
		{
         halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(learningDeck);
        }

        

    }

	private void SetLearningLength(string setting)
	{
		Random r = new Random();

		switch (setting)
		{
			//up to 12 cards----->
			case "1":
				countGoal = r.Next(8, 10);
				break;

			//15-25 cards------>
			case "2":
				countGoal = r.Next(15, 25);
				break;

			//30-40 cards------>
			case "3":
				countGoal = r.Next(30, 40);
				break;
		}
	}

	private bool CheckIfNotEmpty()
	{
		if (learningDeck.Count > 0) return true;
		else return false;

	}

	private void MixDecks()
	{
		foreach (FiszkaDeck deck in selectedDecks)
		{
			foreach (Fiszka fiszka in deck.Deck)
			{
				mixedDecks.Add(fiszka);
			}
		}

		learningDeck = mixedDecks;
	}

    private Fiszka ChooseRandomFiszka(ObservableCollection<Fiszka> deck)
	{
		var r = new Random();
		int n = r.Next(0, deck.Count() - 1);
		while (n == previous_n)
		{
			n = r.Next(0, deck.Count() - 1);
        }
		previous_n = n;
		currentFiszka = deck[n];
		return deck[n];
	}

    private void Refresh()
    {
		fullFiszkaControl.IsVisible = false;
		halfFiszkaControl.IsVisible = true;
		ScoreButtons.IsVisible = false;

        halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(learningDeck);
		halfFiszkaControl.ShowRandomPhrase();

    }

    private void ShowClicked(object sender, EventArgs e)
    {
		fullFiszkaControl.FiszkaObject = currentFiszka;
		fullFiszkaControl.IsVisible = true;
		halfFiszkaControl.IsVisible = false;
		ScoreButtons.IsVisible = true;
    }

	private async void ScoreClicked(object sender, EventArgs e)
    {
		var param = ((Button)sender).CommandParameter;
		double score = Double.Parse((string)param);
		currentFiszka!.AddScore(score);
        count++;
        LearningDeckCount.Text = count + " / " + countGoal;
		sessionScore += score;

		if (count == countGoal)
		{
			sessionScore = sessionScore / count;
			await DisplayAlert(
				"Gratulację!",
				"Ukończyłeś sesję ze średnim wynikiem " + Double.Round(sessionScore, 2),
				"Ok");
            Navigation.RemovePage(this);

        }

		else
		{
            Refresh();
        }

			
	}

}