using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using UWPURILauncher.Pages;

namespace UWPURILauncher
{
    public sealed partial class Shell : Windows.UI.Xaml.Controls.UserControl
    {
        public Shell()
        {
            this.InitializeComponent();
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(About));
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                string pageName = "UWPURILauncher.Pages." + ((string)selectedItem.Tag);
                Type pageType = Type.GetType(pageName);
                contentFrame.Navigate(pageType);
            }
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(MainPage));
        }
    }
}
