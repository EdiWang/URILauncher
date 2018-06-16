using System.Collections.ObjectModel;
using System.Linq;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class RefWindowsSettingsViewModel : UriLaucherViewModelBase
    {
        public RefWindowsSettingsViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var includes = new[] { "Cortana", "Windows Settings", "Devices",
                                   "Network & Internet", "Accounts", "Apps",
                                   "Time and language", "Ease of Access", "Privacy",
                                   "Update & security" };

            var rf = ReferencesContext.Instance.AllReferences.Where(r => includes.Contains(r.Name));
            var categories = rf as Category[] ?? rf.ToArray();
            if (categories.Any())
            {
                foreach (var category in categories)
                {
                    AddCategoryData(category.Name, category.UriReferences.ToList());
                }
            }
        }
    }
}
