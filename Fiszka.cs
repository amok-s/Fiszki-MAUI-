using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    public class Fiszka
    {
        public static ObservableCollection<Fiszka> fiszkaDeck = new ObservableCollection<Fiszka>();

        public string nativePhrase {  get; set; }
        public string translatedPhrase { get; set; }

        public double memoScore
        {
            get
            {
                double endScore = 0;
                foreach (double score in allScores)
                {
                    endScore += score;
                }
                endScore = endScore / allScores.Count;
                return endScore;
            }
        }

        private List<double> allScores = new List<double>();

        public Fiszka(string nativePhrase, string translatedPhrase)
        {
            this.nativePhrase = nativePhrase;
            this.translatedPhrase = translatedPhrase;
            allScores.Add(2.5);

        }

        public static void GetExampleDeck()
        {
            Fiszka.fiszkaDeck.Add(new Fiszka("la maison", "dom"));
            Fiszka.fiszkaDeck.Add(new Fiszka("le chat", "kot"));
            Fiszka.fiszkaDeck.Add(new Fiszka("le chien", "pies"));
            Fiszka.fiszkaDeck.Add(new Fiszka("l'homme", "chłopak"));
            Fiszka.fiszkaDeck.Add(new Fiszka("l'eau", "woda"));
            Fiszka.fiszkaDeck.Add(new Fiszka("le doigt", "palec"));
            Fiszka.fiszkaDeck.Add(new("sac à dos", "plecak"));

            //new ,
            //new Fiszka("le chat", "kot"),
            //new Fiszka("le chien", "pies"),
            //new Fiszka("l'homme", "chłopak"),
            //new Fiszka("l'eau", "woda"),
            //new Fiszka("le doigt", "palec"),
            //new ("sac à dos", "plecak")

        }

        public void AddScore(double score)
        {
            allScores.Add(score);
        }

        public void RemoveFiszka()
        {
            Fiszka.fiszkaDeck.Remove(this);
        }
    }

}
