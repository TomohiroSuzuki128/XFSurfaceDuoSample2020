using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public class MockStationItemDataStore : IDataStore<StationItem>
    {
        readonly List<StationItem> items;

        public MockStationItemDataStore()
        {
            items = new List<StationItem>()
            {
                new StationItem(0001.ToString(),"北千住"),
                new StationItem(0002.ToString(),"南千住"),
                new StationItem(0003.ToString(),"三ノ輪"),
                new StationItem(0004.ToString(),"入谷"),
                new StationItem(0004.ToString(),"上野"),
                new StationItem(0006.ToString(),"仲御徒町"),
            };
        }

        public async Task<bool> AddItemAsync(StationItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(StationItem item)
        {
            var oldItem = items.Where((StationItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((StationItem arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<StationItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<StationItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}