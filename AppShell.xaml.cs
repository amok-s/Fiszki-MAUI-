using Fiszki.Pages;

namespace Fiszki
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddFiszkaPage), typeof(AddFiszkaPage));
            Routing.RegisterRoute(nameof(BrowseFiszkaPage), typeof(BrowseFiszkaPage));
            Routing.RegisterRoute(nameof(LearnPage), typeof(LearnPage));
            Routing.RegisterRoute(nameof(Test), typeof(Test));
            Routing.RegisterRoute(nameof(AddDeckPage), typeof(AddDeckPage));
        }
    }
}
