
namespace Fiszki;

public partial class TestPage : ContentPage
{
	public TestPage()
	{
		InitializeComponent();
		
	}

	private void SortFiszkaPicker_SelectedIndexChanged(object sender, EventArgs e)
	{
		var picker = (Picker)sender;
		int selectedIndex = picker.SelectedIndex;

		if (selectedIndex != -1)
		{
			TestLabel.Text = selectedIndex.ToString();
		}
	}
}