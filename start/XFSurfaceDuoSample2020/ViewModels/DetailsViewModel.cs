using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFSurfaceDuoSample2020.Models;
using XFSurfaceDuoSample2020.Services;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        public ObservableCollection<TimeTableRowItem> TimeTableRowItems { get; set; }

        ITimeTableDataStore timeTableItemDataStore = new MockTimeTableDataStore();

        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set
            {
                SetProperty(ref selectedStationItem, value);
                Name = selectedStationItem.Name;
                SelectStationCommand?.Execute(null);
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public ICommand SelectStationCommand { private set; get; }

        public DetailsViewModel(StationItem selectedStationItem = null)
        {
            SelectedStationItem = selectedStationItem ?? StationItem.Empty;

            TimeTableRowItems = new ObservableCollection<TimeTableRowItem>();

            SelectStationCommand = new Command(() => OnStationSelected());
        }

        void OnStationSelected()
        {
            ChangeTiemTable(SelectedStationItem);
        }

        //public void ChangeSelectedStationItem(StationItem selectedStationItem) =>
        //     SelectedStationItem = selectedStationItem;

        void ChangeTiemTable(StationItem selectedStationItem)
        {
            TimeTableRowItems.Clear();

            Enumerable.Range(6, 14).ForEach
            (
               async x =>
               {
                   var rowItem = new TimeTableRowItem(
                       "Dammy",
                       selectedStationItem.ID,
                       x,
                       string.Empty
                       );
                   (await timeTableItemDataStore.GetItemsEachHourAsync(selectedStationItem.ID, x)).ForEach(y => rowItem.RowText += $"{y.Minute} ");
                   TimeTableRowItems.Add(rowItem);
               }
            );
        }

    }
}
