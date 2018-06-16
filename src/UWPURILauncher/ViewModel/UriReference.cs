using System.Collections.Generic;
using System.Linq;

namespace UWPURILauncher.ViewModel
{
    public class UriReference
    {
        public string Description { get; set; }

        public IEnumerable<string> UriString { get; set; }

        public UriReference()
        {
            
        }

        public UriReference(string description, string uriString)
        {
            UriString = new List<string>() { uriString };
            Description = description;
        }

        public UriReference(string description, IEnumerable<string> uriString)
        {
            UriString = uriString.ToList();
            Description = description;
        }
    }
}
