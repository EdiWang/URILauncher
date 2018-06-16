using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Edi.UWP.Helpers.Extensions;
using GalaSoft.MvvmLight;

namespace UWPURILauncher.ViewModel
{
    public class UriLaucherViewModelBase : ViewModelBase
    {
        public ObservableCollection<Category> UriCategories
        {
            get => _uriCategories;
            set { _uriCategories = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<Category> _uriCategories;

        protected virtual void AddCategoryData(string categoryName, List<UriReference> references)
        {
            var existing = UriCategories.FirstOrDefault(u => u.Name == categoryName);
            if (null != existing)
            {
                var list = existing.UriReferences.ToList();
                list.AddRange(references);
                existing.UriReferences = list;
            }
            else
            {
                UriCategories.Add(new Category()
                {
                    Name = categoryName,
                    UriReferences = references.ToObservableCollection()
                });
            }
        }
    }
}
