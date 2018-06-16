using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using UWPURILauncher.Model;

namespace UWPURILauncher.Common
{
    public class UriHistoryData
    {
        public Repository<IEnumerable<UriHistorySerializeType>> Repository { get; set; }

        public UriHistoryData()
        {
            Repository = new Repository<IEnumerable<UriHistorySerializeType>>("urihistory.json");
        }

        public async Task SaveUriHistoryListDataAsync(IEnumerable<UriHistoryModel> uriHistoryModels)
        {
            List<UriHistorySerializeType> data =
            uriHistoryModels.Select(i => new UriHistorySerializeType
            {
                UriString = i.UriString,
                RanAt = i.RanAt
            }).ToList();

            await Repository.SaveDataAsync(data);
        }

        public async Task ClearUriHistory()
        {
            IEnumerable<UriHistoryModel> uriHistoryModels = new List<UriHistoryModel>();
            await SaveUriHistoryListDataAsync(uriHistoryModels);
        }

        public async Task<IEnumerable<UriHistoryModel>> GetUriHistoryListDataAsync()
        {
            var list = await Repository.LoadDataAsync();
            if (null != list)
            {
                IEnumerable<UriHistoryModel> items = list.Select(i => new UriHistoryModel()
                {
                    UriString = i.UriString,
                    RanAt = i.RanAt
                });
                return items?.ToList();
            }
            return new List<UriHistoryModel>();
        }
    }

    [DataContract]
    public class UriHistorySerializeType
    {
        [DataMember]
        public string UriString { get; set; }

        [DataMember]
        public DateTime RanAt { get; set; }
    }
}
