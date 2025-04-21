

namespace Fiszki;

public partial class BrowseFiszkaPage : ContentPage
{


	public BrowseFiszkaPage()
	{
		InitializeComponent();
        collectionView.ItemsSource = Fiszka.fiszkaDeck;
    }


}