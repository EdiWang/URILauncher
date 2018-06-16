using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWPURILauncher.Common;

namespace UWPURILauncher.ViewModel
{
    public class PersonalizationViewModel : UriLaucherViewModelBase
    {
        public PersonalizationViewModel()
        {
            UriCategories = new ObservableCollection<Category>();
            AddUriReferences();
        }

        private void AddUriReferences()
        {
            var ps = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Personalization");
            if (null != ps)
            {
                AddCategoryData(ps.Name, ps.UriReferences.ToList());
            }
        }
    }
}
