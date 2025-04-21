

using System.Net.NetworkInformation;
using System.Xml.Linq;

namespace Fiszki;

public partial class LearnPage : ContentPage
{
	int previous_n;
	Fiszka? currentFiszka;
	public LearnPage()
	{
		InitializeComponent();
		halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(Fiszka.fiszkaDeck);
		fullFiszkaControl.IsVisible = false;
		ScoreButtons.IsVisible = false;
		
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
		NextClicked(0, null);
	}

    private void PointerGestureRecognizer_PointerEntered(object sender, PointerEventArgs e)
    {
		NextClicked(sender, e);
    }
}