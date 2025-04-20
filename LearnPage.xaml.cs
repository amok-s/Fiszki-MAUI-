

using System.Net.NetworkInformation;

namespace Fiszki;

public partial class LearnPage : ContentPage
{
	
	
	public LearnPage()
	{
		InitializeComponent();
		var lol = Fiszka.fiszkaDeck[Fiszka.fiszkaDeck.Count() - 1];
		cyc.FiszkaObject = lol;
		
    }
}