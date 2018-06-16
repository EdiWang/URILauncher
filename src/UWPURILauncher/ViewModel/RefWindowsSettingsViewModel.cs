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
            var ws = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Windows Settings");
            if (null != ws)
            {
                AddCategoryData(ws.Name, ws.UriReferences.ToList());
            }

            var ds = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Devices");
            if (null != ds)
            {
                AddCategoryData(ds.Name, ds.UriReferences.ToList());
            }

            var ni = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Network & Internet");
            if (null != ni)
            {
                AddCategoryData(ni.Name, ni.UriReferences.ToList());
            }

            var ac = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Accounts");
            if (null != ac)
            {
                AddCategoryData(ac.Name, ac.UriReferences.ToList());
            }

            var ap = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Apps");
            if (null != ap)
            {
                AddCategoryData(ap.Name, ap.UriReferences.ToList());
            }

            var tl = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Time and language");
            if (null != tl)
            {
                AddCategoryData(tl.Name, tl.UriReferences.ToList());
            }

            var ea = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Ease of Access");
            if (null != ea)
            {
                AddCategoryData(ea.Name, ea.UriReferences.ToList());
            }

            var pv = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Privacy");
            if (null != pv)
            {
                AddCategoryData(pv.Name, pv.UriReferences.ToList());
            }

            var us = ReferencesContext.Instance.AllReferences.FirstOrDefault(r => r.Name == "Update & security");
            if (null != us)
            {
                AddCategoryData(us.Name, us.UriReferences.ToList());
            }
        }
    }
}
