
using Fiszki.Controls;
using Fiszki.Data;

namespace Fiszki;

public partial class Test : ContentPage
{
	public Test()
	{
		InitializeComponent();
		
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		//TestLayout.Add(new FiszkaCard());
		TestLayout.Add(new DeckInside(FiszkaDeck.AllDecks[0]));
    }
}