using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using System.Windows.Input;
using Fiszki.Data;

namespace Fiszki;

public partial class BrowseFiszkaPage : ContentPage
{
    public Command TestCommand 
    { 
        get; 
        set;
    }

    public BrowseFiszkaPage()
	{
        InitializeComponent();
        BindableLayout.SetItemsSource(DeckCollectionView, FiszkaDeck.AllDecks);

        TestCommand = new Command(
            execute: () =>
            {
                Move();
            },
            canExecute: () =>
            {
                return true;
            });
    }

    
    Task Move() => Shell.Current.GoToAsync(nameof(AddFiszkaPage));

}

