using System.Collections.Generic;

namespace UWPURILauncher.ViewModel
{
    public class Category
    {
        public string Name { get; set; }

        public IEnumerable<UriReference> UriReferences { get; set; }

        public Category()
        {
            UriReferences = new List<UriReference>();
        }
    }
}
