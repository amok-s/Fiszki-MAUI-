

using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Xml.Linq;
using Fiszki.Data;

namespace Fiszki;

public partial class LearnPage : ContentPage
{   
	
	//-----bindable properties-------
    public static readonly BindableProperty FiszkaObjectProperty = BindableProperty.Create(nameof(FiszkaObject), typeof(Fiszka), typeof(LearnPage), null);
    public Fiszka FiszkaObject
    {
        get => (Fiszka)GetValue(FiszkaObjectProperty);
        set => SetValue(FiszkaObjectProperty, value);
    }



    public static ObservableCollection<FiszkaDeck> selectedDecks;
	int previous_n;
	FiszkaDeck? currentDeck;
	Fiszka? currentFiszka;
	
	public LearnPage()
	{
		InitializeComponent();
		selectedDecks = FiszkaDeck.AllDecks;

		FiszkaObject = (FiszkaDeck.AllDecks[0]).Deck[0];


		currentDeck = FiszkaDeck.AllDecks[0];
        fullFiszkaControl.IsVisible = false;
        ScoreButtons.IsVisible = false;

        if (CheckIfNotEmpty())
		{
         halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(currentDeck.Deck);
        }

        fullFiszkaControl.IsEditable = false;

    }


	private bool CheckIfNotEmpty()
	{
		if (currentDeck.Deck.Count > 0) return true;
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

        halfFiszkaControl.FiszkaObject = ChooseRandomFiszka(currentDeck.Deck);
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