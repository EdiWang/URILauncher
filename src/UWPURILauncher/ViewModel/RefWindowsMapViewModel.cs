using System.Collections.ObjectModel;
using System.Linq;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class RefWindowsMapViewModel : UriLaucherViewModelBase
    {
        public RefWindowsMapViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var wm = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Windows Maps");
            if (null != wm)
            {
                AddCategoryData(wm.Name, wm.UriReferences.ToList());
            }
        }
    }
}
