using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiszki
{
    internal class Fiszka
    {
        public static List<Fiszka> fiszkaDeck = new List<Fiszka>();
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
    }
}
