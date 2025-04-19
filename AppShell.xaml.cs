namespace Fiszki
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddFiszkaPage), typeof(AddFiszkaPage));
            Routing.RegisterRoute(nameof(BrowseFiszkaPage), typeof(BrowseFiszkaPage));
        }
    }
}
