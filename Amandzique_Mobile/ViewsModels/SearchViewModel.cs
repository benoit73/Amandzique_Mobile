using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amandzique_Mobile.ViewsModels
{
    public class SearchViewModel : INotifyPropertyChanged
    {
        private List<string> _musiquesCollection;
        public List<string> MusiquesCollection
        {
            get { return _musiquesCollection; }
            set
            {
                _musiquesCollection = value;
                OnPropertyChanged("MusiquesCollection");
            }
        }
        private string _musiqueSearched;
        public string MusiqueSearched
        {
            get { return _musiqueSearched; }
            set
            {
                _musiqueSearched = value;
                OnPropertyChanged("MusiqueSearched");
                InitializeAsync(_musiqueSearched);
            }
        }
        public SearchViewModel()
        {
        }

        private async Task InitializeAsync(string _musiqueSearched)
        {
            MusiquesCollection = await Search(_musiqueSearched);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public async Task<List<string>> Search(string _musiqueSearched)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = "-",
                ApplicationName = this.GetType().ToString()
            });

            var searchListRequest = youtubeService.Search.List("snippet");
            searchListRequest.Q = _musiqueSearched; // Replace with your search term.
            searchListRequest.MaxResults = 50;

            // Call the search.list method to retrieve results matching the specified query term.
            var searchListResponse = await searchListRequest.ExecuteAsync();

            List<string> videos = new List<string>();


            // Add each result to the appropriate list, and then display the lists of
            // matching videos, channels, and playlists.
            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(String.Format("{0} ({1})", searchResult.Snippet.Title, searchResult.Id.VideoId));
                        break;
                }
            }

            return videos;

        }
    }
    
}
