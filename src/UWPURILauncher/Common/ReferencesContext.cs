using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Windows.ApplicationModel;
using UWPURILauncher.ViewModel;

namespace UWPURILauncher.Common
{
    public class ReferencesContext
    {
        #region Singleton

        private static readonly Lazy<ReferencesContext> Lazy = new Lazy<ReferencesContext>(() => new ReferencesContext());

        public static ReferencesContext Instance => Lazy.Value;

        private ReferencesContext()
        {
        }

        #endregion

        public List<Category> AllReferences { get; private set; }

        public bool HasDataInitialized { get; set; }

        public async Task InitDataAsync()
        {
            if (HasDataInitialized)
            {
                return;
            }

            string s = await GetXmlStringAsync("Data/References.xml");
            var doc = XDocument.Parse(s);
            var cats = from p in doc.Descendants("Category")
                       select new Category()
                       {
                           Name = (string)p.Attribute(nameof(Category.Name)),
                           UriReferences = from r in p.Descendants(nameof(UriReference))
                                           select new UriReference()
                                           {
                                               Description = (string)r.Attribute(nameof(UriReference.Description)),
                                               UriString = from str in r.Descendants(nameof(UriReference.UriString))
                                                           select (string)str.Attribute("Content")
                                           }
                       };

            var catsList = cats.ToList();

            if (null == AllReferences)
            {
                AllReferences = catsList;
            }

            HasDataInitialized = true;
        }

        private static async Task<string> GetXmlStringAsync(string assetsFileName)
        {
            var storageFile = await Package.Current.InstalledLocation.GetFileAsync($"Assets/{assetsFileName}".Replace('/', '\\'));
            var fStream = await storageFile.OpenReadAsync();

            var stream = fStream.AsStream();

            if (stream == null)
            {
                throw new FileNotFoundException("Could not find embedded mappings resource file.");
            }

            var reader = new StreamReader(stream);
            string s = reader.ReadToEnd();
            return s;
        }
    }
}
