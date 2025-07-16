

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
            Routing.RegisterRoute(nameof(LearnSetupPage), typeof(LearnSetupPage));
            Routing.RegisterRoute(nameof(DebugMenu), typeof(DebugMenu));
            Routing.RegisterRoute(nameof(TestPage), typeof(TestPage));
        }
    }
}
