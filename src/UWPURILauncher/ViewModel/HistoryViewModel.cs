using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Edi.UWP.Helpers.Extensions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UWPURILauncher.Common;
using UWPURILauncher.Model;

namespace UWPURILauncher.ViewModel
{
    public class HistoryViewModel : ViewModelBase
    {
        UriHistoryData data = new UriHistoryData();

        private ObservableCollection<UriHistoryModel> _uriHistoryModels;

        public ObservableCollection<UriHistoryModel> UriHistoryModels
        {
            get => _uriHistoryModels;
            set { _uriHistoryModels = value; RaisePropertyChanged(); }
        }

        public async Task InitData()
        {
            var oldData = await data.GetUriHistoryListDataAsync();
            UriHistoryModels = oldData.ToObservableCollection();
        }

        public RelayCommand CommandClearHistory { get; set; }

        public HistoryViewModel()
        {
            CommandClearHistory = new RelayCommand(async () => await ClearHistory());
        }

        public async Task ClearHistory()
        {
            await data.ClearUriHistory();
            UriHistoryModels = new ObservableCollection<UriHistoryModel>();
        }
    }
}
