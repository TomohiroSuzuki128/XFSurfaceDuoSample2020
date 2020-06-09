using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public interface ILineDataStore
    {
        Task<bool> AddItemAsync(LineItem item);
        Task<bool> UpdateItemAsync(LineItem item);
        Task<bool> DeleteItemAsync(string id);
        Task<LineItem> GetItemAsync(string id);
        Task<IEnumerable<LineItem>> GetItemsAsync(bool forceRefresh = false);
    }
}
