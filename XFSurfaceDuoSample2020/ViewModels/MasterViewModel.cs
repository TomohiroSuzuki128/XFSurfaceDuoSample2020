using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using XFSurfaceDuoSample2020.Models;
using XFSurfaceDuoSample2020.Services;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        public ObservableCollection<StationItem> StationItems { get; set; }

        MockStationItemDataStore mockStationItemDataStore = new MockStationItemDataStore();

        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set { SetProperty(ref selectedStationItem, value); }
        }

        public MasterViewModel()
        {
            Initialize();
        }

        async void Initialize()
        {
            Title = "Master";
            StationItems = new ObservableCollection<StationItem>();
            (await mockStationItemDataStore.GetItemsAsync()).ForEach(x => StationItems.Add(x));
            SelectedStationItem = StationItem.Empty;
        }

        public void ChangeSelectedStationItem(StationItem selectedStationItem) =>
             SelectedStationItem = selectedStationItem;

        public ICommand OpenWebCommand { get; }
    }
}


