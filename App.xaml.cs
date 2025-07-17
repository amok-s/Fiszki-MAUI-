using Microsoft.Maui.Controls.PlatformConfiguration;


namespace Fiszki
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

#if WINDOWS10_0_19041_0_OR_GREATER
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping(nameof(IPicker.Title), (handler, view) =>
            {
                if (handler.PlatformView is not null && view is Picker pick && !String.IsNullOrWhiteSpace(pick.Title))
                {
                    handler.PlatformView.HeaderTemplate = new Microsoft.UI.Xaml.DataTemplate();
                    handler.PlatformView.PlaceholderText = pick.Title;
                    pick.Title = null;
                }
            });
#endif
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            const int newheight = 715;
            const int newwidth = 1215;

            var wins = new Window(new AppShell());
            //var wins = new Window(new ContentDemo());
            wins.Height = newheight;
            wins.Width = newwidth;
            return wins;
        }
    }
}