using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public interface IStationDataStore
    {
        Task<bool> AddItemAsync(StationItem item);
        Task<bool> UpdateItemAsync(StationItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<StationItem> GetItemAsync(string id);
        Task<IEnumerable<StationItem>> GetItemsAsync(string lineID, bool forceRefresh = false);
    }
}
