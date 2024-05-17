using Amandzique_Mobile.Views;

namespace Amandzique_Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }


        private void BtnSearch_Clicked(object sender, EventArgs e)
        {
            MainFrame.Content = new SearchPage();
        }

        private void BtnPlaylist_Clicked(object sender, EventArgs e)
        {
            MainFrame.Content = new PlaylistPage();
        }
    }

}
