using System.Collections.ObjectModel;


namespace Fiszki.Data
{
    public class Fiszka
    {
        public DateTime LastTimeLearn { get; set; }
        public string NativePhrase {  get; set; }
        public string TranslatedPhrase { get; set; }
        public double MemoScore
        {
            get
            {
                double endScore = 0;
                foreach (double score in AllScores)
                {
                    endScore += score;
                }
                endScore = endScore / AllScores.Count;
                return endScore;
            }
        }

        private List<double> AllScores = new List<double>();

        public ObservableCollection<string> DecksIsIn = new ObservableCollection<string>();

        
        //-----Constructor--->
        public Fiszka(string nativePhrase, string translatedPhrase)
        {
            this.NativePhrase = nativePhrase;
            this.TranslatedPhrase = translatedPhrase;
            AllScores.Add(0);
            LastTimeLearn = DateTime.Now;
        }

        //--------Methods--->
        public void AddScore(double score)
        {
            AllScores.Add(score);
            LastTimeLearn = DateTime.Now;
            if (AllScores.Count > 15)
            {
                AllScores.RemoveAt(0);
            }
        }

        public void RemoveFiszka(FiszkaDeck deck)
        {
            deck.Deck.Remove(this);
        }
    }

}
