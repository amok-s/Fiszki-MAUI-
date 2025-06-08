

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

    private void StartSessionButton_Clicked(object sender, EventArgs e)
    {
		int howManyCards;
		Random r = new Random();
		

    }
}