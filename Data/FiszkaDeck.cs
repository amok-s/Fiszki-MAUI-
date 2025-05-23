﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki.Data
{
    public class FiszkaDeck
    {
        public static ObservableCollection<FiszkaDeck> AllDecks = new ObservableCollection<FiszkaDeck>();

        
        //-----Properties--->
        public string Name { get; set; }
        public ObservableCollection<Fiszka> Deck { get; set; }

        public bool ShowFiszkaInDeck { get; set; } = false;

        //-----Constructor--->
        public FiszkaDeck(string name)
        {
            if (String.IsNullOrWhiteSpace(name))
            { Name = "NowaLista"; }
            else
            {
                Name = name;
            }
            Deck = new ObservableCollection<Fiszka>();
        }
    
        //----Methods--->
        public void Sort()
        {
            Deck.OrderBy(x => x.MemoScore);
        }

        public void AddFiszka(Fiszka fiszka)
        {
            Deck.Add(fiszka);
            if (!fiszka.DecksIsIn.Contains(Name))
            {
                fiszka.DecksIsIn.Add(Name);
            }
        }

        public void RemoveFiszka(Fiszka fiszka)
        {
            if (fiszka.DecksIsIn.Contains(Name))
            {
                fiszka.DecksIsIn.Remove(Name);
            }
            Deck.Remove(fiszka);
        }

        static public void RemoveDeck(FiszkaDeck selectedDeck)
        {
            AllDecks.Remove(selectedDeck);
        }

        static public void AddDeck(string deckName)
        {
            var x = new FiszkaDeck(deckName);
            AllDecks.Insert(0, x);
        }

  

    }
}
