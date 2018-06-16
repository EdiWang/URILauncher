using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace UWPURILauncher.UserControl
{
    public sealed partial class ReferencesList : Windows.UI.Xaml.Controls.UserControl
    {
        public ReferencesList()
        {
            this.InitializeComponent();
        }

        private async void BtnLaunch_OnClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                string uriString = button.DataContext as string;
                try
                {
                    if (uriString != null)
                    {
                        var uri = new Uri(uriString.Trim());
                        await Launcher.LaunchUriAsync(uri);
                    }
                }
                catch (Exception ex)
                {
                    var dig = new MessageDialog(ex.Message, "Error");
                    await dig.ShowAsync();
                }
            }
        }
    }
}
