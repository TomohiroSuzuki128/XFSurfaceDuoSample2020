using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public interface ITimeTableDataStore
    {
        Task<bool> AddItemAsync(TimeTableItem item);
        Task<bool> UpdateItemAsync(TimeTableItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<TimeTableItem> GetItemAsync(string id);
        Task<IEnumerable<TimeTableItem>> GetItemsAsync(string StationID, bool forceRefresh = false);
        Task<IEnumerable<TimeTableItem>> GetItemsEachHourAsync(string stationID, int hour, bool forceRefresh = false);
    }
}
