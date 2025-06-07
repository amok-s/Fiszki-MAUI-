

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

		DeckListView.ItemsSource = FiszkaDeck.AllDecks;
    }


	


}