using System;

namespace UWPURILauncher.Model
{
    public class UriHistoryModel
    {
        public string UriString { get; set; }

        public DateTime RanAt { get; set; }

        public UriHistoryModel()
        {
            UriString = string.Empty;
            RanAt = DateTime.Now;
        }
    }
}
