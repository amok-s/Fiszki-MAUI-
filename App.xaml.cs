namespace Fiszki
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int newheight = 715;
            const int newwidth = 1215;

            //var wins = new Window(new AppShell());
            var wins = new Window(new ContentDemo());
            wins.Height = newheight;
            wins.Width = newwidth;
            return wins;
        }
    }
}