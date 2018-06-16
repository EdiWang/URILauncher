using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace UWPURILauncher.ViewModel
{
    public class AboutViewModel : ViewModelBase
    {
        public Uri Logo => Edi.UWP.Helpers.Utils.GetAppLogoUri();

        public string DisplayName => Edi.UWP.Helpers.Utils.GetAppDisplayName();

        public string Publisher => Edi.UWP.Helpers.Utils.GetAppPublisher();

        public string Version => Edi.UWP.Helpers.Utils.GetAppVersion();

        public RelayCommand CommandReview { get; set; }

        public AboutViewModel()
        {
            CommandReview = new RelayCommand(async () => await Edi.UWP.Helpers.Tasks.OpenStoreReviewAsync());
        }
    }
}
