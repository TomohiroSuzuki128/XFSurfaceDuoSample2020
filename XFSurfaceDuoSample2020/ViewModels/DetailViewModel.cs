using System;

using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class DetailViewModel : ViewModelBase
    {
        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set { SetProperty(ref selectedStationItem, value); }
        }

        public DetailViewModel(StationItem selectedStationItem = null)
        {
            SelectedStationItem = selectedStationItem;
        }

    }
}
