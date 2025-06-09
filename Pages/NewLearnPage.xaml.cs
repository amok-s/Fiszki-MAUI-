

using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Fiszki.Data;

namespace Fiszki;

public partial class NewLearnPage : ContentPage
{   
	
    public static ObservableCollection<FiszkaDeck> selectedDecks;
    ObservableCollection<Fiszka> learningDeck = new ObservableCollection<Fiszka>();
    int previous_n;
	Fiszka? currentFiszka;
	
	public NewLearnPage(string lengthSetting, ObservableCollection<FiszkaDeck> decks)
	{
		InitializeComponent();
		ChosenSettingLabel.Text = "Wybrana długość: " + lengthSetting;
        fullFiszkaControl.IsEditable = false;
		selectedDecks = decks;
		MixDecks();
        fullFiszkaControl.IsVisible = false;
        ScoreButtons.IsVisible = false;

        if (CheckIfNotEmpty())
		{
         halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(learningDeck);
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
				learningDeck.Add(fiszka);
			}
		}

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

    private void Refresh(object sender, EventArgs e)
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

	private void ScoreClicked(object sender, EventArgs e)
    {
		var param = ((Button)sender).CommandParameter;
		double score = Double.Parse((string)param);
		currentFiszka.AddScore(score);
		Refresh(0, null);
	}


}