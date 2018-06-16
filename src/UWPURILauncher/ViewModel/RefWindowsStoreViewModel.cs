using System.Collections.ObjectModel;
using System.Linq;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class RefWindowsStoreViewModel : UriLaucherViewModelBase
    {
        public RefWindowsStoreViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var ws = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Windows Store");
            if (null != ws)
            {
                AddCategoryData(ws.Name, ws.UriReferences.ToList());
            }
        }
    }
}
