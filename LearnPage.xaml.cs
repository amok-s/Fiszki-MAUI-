

using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace Fiszki;

public partial class LearnPage : ContentPage
{
	int previous_n;
	Fiszka? currentFiszka;
	ObservableCollection<Fiszka>? currentDeck;
	
	public LearnPage()
	{
		InitializeComponent();

        Fiszka.fiszkaDeck.CollectionChanged += FiszkaDeck_CollectionChanged;
        fullFiszkaControl.IsVisible = false;
        ScoreButtons.IsVisible = false;
		currentDeck = Fiszka.fiszkaDeck;

        if (CheckIfNotEmpty())
		{
         halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(Fiszka.fiszkaDeck);
        }
	}


	private bool CheckIfNotEmpty()
	{
		if (currentDeck.Count > 0) return true;
		else return false;

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

        halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(Fiszka.fiszkaDeck);
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

    private async void FiszkaDeck_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        await DisplayAlert(
				"",
				"Usunięto fiszkę!",
				"ok");

		Refresh(0, null);
    }

}