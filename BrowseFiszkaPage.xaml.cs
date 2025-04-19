

namespace Fiszki;

public partial class BrowseFiszkaPage : ContentPage
{
    Fiszka? currentFiszka;
    int n = 0;

	public BrowseFiszkaPage()
	{
		InitializeComponent();
        if (Fiszka.fiszkaDeck.Count > 0)
        {
            currentFiszka = Fiszka.fiszkaDeck[n];
            NativePhraseLabel.Text = currentFiszka.nativePhrase;
            TranslatedPhraseLabel.Text = currentFiszka.translatedPhrase;
            ScoreLabel.Text = "Score: " + currentFiszka.memoScore.ToString();
        }

    }

    private void PreviousBtn_Clicked(object sender, EventArgs e)
    {
        if (n > 0)
        {
            n -= 1;
            loadFiszka(n);
        }
    }

    private void NextBtn_Clicked(object sender, EventArgs e)
    {
        if (n < Fiszka.fiszkaDeck.Count - 1)
        {
            n += 1;
            loadFiszka(n);
        }
    }

    private void loadFiszka(int position)
    {
        currentFiszka = Fiszka.fiszkaDeck[n];
        NativePhraseLabel.Text = currentFiszka.nativePhrase;
        TranslatedPhraseLabel.Text = currentFiszka.translatedPhrase;
    }
}