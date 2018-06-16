using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using UWPURILauncher.ViewModel;

namespace UWPURILauncher.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class History : Page
    {
        public History()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var vm = DataContext as HistoryViewModel;
            if (null != vm)
            {
                await vm.InitData();
            }
        }
    }
}
