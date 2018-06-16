using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.System;
using Windows.UI.Popups;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using UWPURILauncher.Common;
using UWPURILauncher.Model;

namespace UWPURILauncher.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        UriHistoryData data = new UriHistoryData();

        private string _uriString;

        public string UriString
        {
            get => _uriString;
            set { _uriString = value; RaisePropertyChanged(); }
        }

        public RelayCommand CommandLaunch { get; set; }

        public MainViewModel()
        {
            UriString = "ms-settings:";
            CommandLaunch = new RelayCommand(async () => await DoLaunch());
        }

        private async Task DoLaunch()
        {
            try
            {
                var uri = new Uri(UriString.Trim());
                await Launcher.LaunchUriAsync(uri);
                var history = new UriHistoryModel() { UriString = this.UriString };
                
                var oldData = await data.GetUriHistoryListDataAsync();
                var uriHistoryModels = oldData as UriHistoryModel[] ?? oldData.ToArray();
                var newData = uriHistoryModels.ToList();
                newData.Add(history);
                await data.SaveUriHistoryListDataAsync(newData);
            }
            catch (Exception ex)
            {
                var dig = new MessageDialog(ex.Message, "Error");
                await dig.ShowAsync();
            }
        }
    }
}
