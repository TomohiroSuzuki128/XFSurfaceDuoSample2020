using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public class MockLineItemDataStore : IDataStore<LineItem>
    {
        readonly List<LineItem> items;

        public MockLineItemDataStore()
        {
            items = new List<LineItem>()
            {
                new LineItem(0001.ToString(),"日比谷線"),
                new LineItem(0002.ToString(),"東西線"),
                new LineItem(0003.ToString(),"千代田線"),
            };
        }

        public async Task<bool> AddItemAsync(LineItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(LineItem item)
        {
            var oldItem = items.Where((LineItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((LineItem arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<LineItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<LineItem>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

    }
}