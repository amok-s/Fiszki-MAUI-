

using System.Net.NetworkInformation;

namespace Fiszki;

public partial class LearnPage : ContentPage
{
	int previous_n;
	Fiszka currentFiszka;
	public LearnPage()
	{
		InitializeComponent();
		halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(Fiszka.fiszkaDeck);
		fullFiszkaControl.IsVisible = false;
	}

	private Fiszka ChooseRandomFiszka(IList<Fiszka> deck)
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

    private void NextClicked(object sender, EventArgs e)
    {
		fullFiszkaControl.IsVisible = false;
		halfFiszkaControl.IsVisible = true;
        halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(Fiszka.fiszkaDeck);
		halfFiszkaControl.ShowRandomPhrase();

    }

    private void ShowClicked(object sender, EventArgs e)
    {
		fullFiszkaControl.FiszkaObject = currentFiszka;
		fullFiszkaControl.IsVisible = true;
		halfFiszkaControl.IsVisible = false;
    }


}