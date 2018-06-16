using System.Collections.ObjectModel;
using System.Linq;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class KnownAppsViewModel : UriLaucherViewModelBase
    {
        public KnownAppsViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var ka = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Known Apps");
            if (null != ka)
            {
                AddCategoryData(ka.Name, ka.UriReferences.ToList());
            }
        }
    }
}
