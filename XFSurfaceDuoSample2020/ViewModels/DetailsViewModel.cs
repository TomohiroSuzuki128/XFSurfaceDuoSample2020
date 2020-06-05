using System;

using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class DetailsViewModel : ViewModelBase
    {
        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set
            {
                SetProperty(ref selectedStationItem, value);
                Name = selectedStationItem.Name;
            }
        }

        string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public DetailsViewModel(StationItem selectedStationItem = null) =>
            SelectedStationItem = selectedStationItem ?? StationItem.Empty;

        public void ChangeSelectedStationItem(StationItem selectedStationItem) =>
             SelectedStationItem = selectedStationItem;
    }
}
