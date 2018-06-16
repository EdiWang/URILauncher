using System.Collections.ObjectModel;
using System.Linq;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class RefGamingViewModel : UriLaucherViewModelBase
    {
        public RefGamingViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var obj = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Gaming");
            if (null != obj)
            {
                AddCategoryData(obj.Name, obj.UriReferences.ToList());
            }
        }
    }
}
