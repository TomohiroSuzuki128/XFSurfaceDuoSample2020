using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.Services
{
    public class MockTimeTableDataStore : ITimeTableDataStore
    {
        readonly List<TimeTableItem> items;

        public MockTimeTableDataStore()
        {
            items = new List<TimeTableItem>()
            {
                new TimeTableItem("A0101", "A01", 10, 5),
                new TimeTableItem("A0102", "A01", 11, 5),
                new TimeTableItem("A0103", "A01", 12, 5),
                new TimeTableItem("A0104", "A01", 13, 5),
                new TimeTableItem("A0105", "A01", 14, 5),
                new TimeTableItem("A0106", "A01", 15, 5),
                new TimeTableItem("A0107", "A01", 16, 5),
                new TimeTableItem("A0108", "A01", 17, 5),
                new TimeTableItem("A0109", "A01", 18, 5),

                new TimeTableItem("A0201", "A02", 10, 10),
                new TimeTableItem("A0202", "A02", 11, 10),
                new TimeTableItem("A0203", "A02", 12, 10),
                new TimeTableItem("A0204", "A02", 13, 10),
                new TimeTableItem("A0205", "A02", 14, 10),
                new TimeTableItem("A0206", "A02", 15, 10),
                new TimeTableItem("A0207", "A02", 16, 10),
                new TimeTableItem("A0208", "A02", 17, 10),
                new TimeTableItem("A0209", "A02", 18, 10),

                new TimeTableItem("A0301", "A03", 10, 15),
                new TimeTableItem("A0302", "A03", 11, 15),
                new TimeTableItem("A0303", "A03", 12, 15),
                new TimeTableItem("A0304", "A03", 13, 15),
                new TimeTableItem("A0305", "A03", 14, 15),
                new TimeTableItem("A0306", "A03", 15, 15),
                new TimeTableItem("A0307", "A03", 16, 15),
                new TimeTableItem("A0308", "A03", 17, 15),
                new TimeTableItem("A0309", "A03", 18, 15),

                new TimeTableItem("A0401", "A04", 10, 20),
                new TimeTableItem("A0402", "A04", 11, 20),
                new TimeTableItem("A0403", "A04", 12, 20),
                new TimeTableItem("A0404", "A04", 13, 20),
                new TimeTableItem("A0405", "A04", 14, 20),
                new TimeTableItem("A0406", "A04", 15, 20),
                new TimeTableItem("A0407", "A04", 16, 20),
                new TimeTableItem("A0408", "A04", 17, 20),
                new TimeTableItem("A0409", "A04", 18, 20),

                new TimeTableItem("A0501", "A05", 10, 25),
                new TimeTableItem("A0502", "A05", 11, 25),
                new TimeTableItem("A0503", "A05", 12, 25),
                new TimeTableItem("A0504", "A05", 13, 25),
                new TimeTableItem("A0505", "A05", 14, 25),
                new TimeTableItem("A0506", "A05", 15, 25),
                new TimeTableItem("A0507", "A05", 16, 25),
                new TimeTableItem("A0508", "A05", 17, 25),
                new TimeTableItem("A0509", "A05", 18, 25),

                new TimeTableItem("A0601", "A06", 10, 30),
                new TimeTableItem("A0602", "A06", 11, 30),
                new TimeTableItem("A0603", "A06", 12, 30),
                new TimeTableItem("A0604", "A06", 13, 30),
                new TimeTableItem("A0605", "A06", 14, 30),
                new TimeTableItem("A0606", "A06", 15, 30),
                new TimeTableItem("A0607", "A06", 16, 30),
                new TimeTableItem("A0608", "A06", 17, 30),
                new TimeTableItem("A0609", "A06", 18, 30),

                new TimeTableItem("B0101", "B01", 10, 5),
                new TimeTableItem("B0102", "B01", 11, 5),
                new TimeTableItem("B0103", "B01", 12, 5),
                new TimeTableItem("B0104", "B01", 13, 5),
                new TimeTableItem("B0105", "B01", 14, 5),
                new TimeTableItem("B0106", "B01", 15, 5),
                new TimeTableItem("B0107", "B01", 16, 5),
                new TimeTableItem("B0108", "B01", 17, 5),
                new TimeTableItem("B0109", "B01", 18, 5),

                new TimeTableItem("B0201", "B02", 10, 10),
                new TimeTableItem("B0202", "B02", 11, 10),
                new TimeTableItem("B0203", "B02", 12, 10),
                new TimeTableItem("B0204", "B02", 13, 10),
                new TimeTableItem("B0205", "B02", 14, 10),
                new TimeTableItem("B0206", "B02", 15, 10),
                new TimeTableItem("B0207", "B02", 16, 10),
                new TimeTableItem("B0208", "B02", 17, 10),
                new TimeTableItem("B0209", "B02", 18, 10),

                new TimeTableItem("B0301", "B03", 10, 15),
                new TimeTableItem("B0302", "B03", 11, 15),
                new TimeTableItem("B0303", "B03", 12, 15),
                new TimeTableItem("B0304", "B03", 13, 15),
                new TimeTableItem("B0305", "B03", 14, 15),
                new TimeTableItem("B0306", "B03", 15, 15),
                new TimeTableItem("B0307", "B03", 16, 15),
                new TimeTableItem("B0308", "B03", 17, 15),
                new TimeTableItem("B0309", "B03", 18, 15),

                new TimeTableItem("B0401", "B04", 10, 20),
                new TimeTableItem("B0402", "B04", 11, 20),
                new TimeTableItem("B0403", "B04", 12, 20),
                new TimeTableItem("B0404", "B04", 13, 20),
                new TimeTableItem("B0405", "B04", 14, 20),
                new TimeTableItem("B0406", "B04", 15, 20),
                new TimeTableItem("B0407", "B04", 16, 20),
                new TimeTableItem("B0408", "B04", 17, 20),
                new TimeTableItem("B0409", "B04", 18, 20),

                new TimeTableItem("B0501", "B05", 10, 25),
                new TimeTableItem("B0502", "B05", 11, 25),
                new TimeTableItem("B0503", "B05", 12, 25),
                new TimeTableItem("B0504", "B05", 13, 25),
                new TimeTableItem("B0505", "B05", 14, 25),
                new TimeTableItem("B0506", "B05", 15, 25),
                new TimeTableItem("B0507", "B05", 16, 25),
                new TimeTableItem("B0508", "B05", 17, 25),
                new TimeTableItem("B0509", "B05", 18, 25),

                new TimeTableItem("B0601", "B06", 10, 30),
                new TimeTableItem("B0602", "B06", 11, 30),
                new TimeTableItem("B0603", "B06", 12, 30),
                new TimeTableItem("B0604", "B06", 13, 30),
                new TimeTableItem("B0605", "B06", 14, 30),
                new TimeTableItem("B0606", "B06", 15, 30),
                new TimeTableItem("B0607", "B06", 16, 30),
                new TimeTableItem("B0608", "B06", 17, 30),
                new TimeTableItem("B0609", "B06", 18, 30),
            };
        }

        public async Task<bool> AddItemAsync(TimeTableItem item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(TimeTableItem item)
        {
            var oldItem = items.Where((TimeTableItem arg) => arg.ID == item.ID).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((TimeTableItem arg) => arg.ID == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<TimeTableItem> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.ID == id));
        }

        public async Task<IEnumerable<TimeTableItem>> GetItemsAsync(string stationID, bool forceRefresh = false)
        {
            return await Task.FromResult(items.Where(x => stationID == x.StationID));
        }

        public async Task<IEnumerable<TimeTableItem>> GetItemsEachHourAsync(string stationID, int hour, bool forceRefresh = false)
        {
            return await Task.FromResult(items.Where(x => stationID == x.StationID && hour == x.Hour).OrderBy(x => x.Minute));
        }

    }
}