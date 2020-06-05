using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public class MockStationDataStore : IStationDataStore<StationItem>
    {
        readonly List<StationItem> items;

        public MockStationDataStore()
        {
            items = new List<StationItem>()
            {
                new StationItem("A", "A01", "北出粉度"),
                new StationItem("A", "A02", "新出粉度"),
                new StationItem("A", "A03", "中央出粉度"),
                new StationItem("A", "A04", "出粉度市"),
                new StationItem("A", "A04", "南出粉度"),
                new StationItem("A", "A06", "出粉度口"),

                new StationItem("B", "B01", "北左笛洲"),
                new StationItem("B", "B02", "新左笛洲"),
                new StationItem("B", "B03", "中央左笛洲"),
                new StationItem("B", "B04", "左笛洲市"),
                new StationItem("B", "B04", "南左笛洲"),
                new StationItem("B", "B06", "左笛洲口"),
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

        public async Task<IEnumerable<StationItem>> GetItemsAsync(string lineID, bool forceRefresh = false)
        {
            return await Task.FromResult(items.Where(x => lineID == x.LineID));
        }

    }
}