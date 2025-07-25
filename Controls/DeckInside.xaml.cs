﻿using Fiszki.Data;

namespace Fiszki.Controls;

public partial class DeckInside : ContentView
{
    public static readonly BindableProperty DeckObjectProperty = BindableProperty.Create(nameof(DeckObject), typeof(FiszkaDeck), typeof(DeckCard), null);
    public FiszkaDeck DeckObject
    {
        get => (FiszkaDeck)GetValue(DeckObjectProperty);
        set => SetValue(DeckObjectProperty, value);
    }

    public DeckInside(FiszkaDeck deck)
    {
        DeckObject = deck;
        InitializeComponent();
    }

    private void SortFiszkaPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
            DeckObject.SortBy(selectedIndex);
        }
    }
}