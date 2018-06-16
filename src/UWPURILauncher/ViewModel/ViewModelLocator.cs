using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using UWPURILauncher.Pages;

namespace UWPURILauncher.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AboutViewModel>();
            SimpleIoc.Default.Register<HistoryViewModel>();
            SimpleIoc.Default.Register<RefWindowsStoreViewModel>();
            SimpleIoc.Default.Register<RefWindowsSettingsViewModel>();
            SimpleIoc.Default.Register<RefWindowsMapViewModel>();
            SimpleIoc.Default.Register<RefGamingViewModel>();
            SimpleIoc.Default.Register<PersonalizationViewModel>();
            SimpleIoc.Default.Register<KnownAppsViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public AboutViewModel About => ServiceLocator.Current.GetInstance<AboutViewModel>();

        public HistoryViewModel History => ServiceLocator.Current.GetInstance<HistoryViewModel>();

        public RefWindowsStoreViewModel RefWindowsStore => ServiceLocator.Current.GetInstance<RefWindowsStoreViewModel>();

        public RefWindowsSettingsViewModel RefWindowsSettings => ServiceLocator.Current.GetInstance<RefWindowsSettingsViewModel>();

        public RefWindowsMapViewModel RefWindowsMap => ServiceLocator.Current.GetInstance<RefWindowsMapViewModel>();

        public RefGamingViewModel RefGaming => ServiceLocator.Current.GetInstance<RefGamingViewModel>();

        public PersonalizationViewModel RefPersonalization => ServiceLocator.Current.GetInstance<PersonalizationViewModel>();

        public KnownAppsViewModel KnownApps => ServiceLocator.Current.GetInstance<KnownAppsViewModel>();
    }
}
