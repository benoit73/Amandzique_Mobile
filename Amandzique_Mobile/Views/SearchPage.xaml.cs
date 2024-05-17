namespace Amandzique_Mobile.Views;
using Amandzique_Mobile.ViewsModels;
public partial class SearchPage : ContentView
{
	public SearchPage()
	{
		InitializeComponent();
		this.BindingContext = new SearchViewModel();
	}


}