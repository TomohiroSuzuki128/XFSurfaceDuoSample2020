using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms.Internals;
using XFSurfaceDuoSample2020.Models;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        public ObservableCollection<StationItem> StationItems { get; set; }

        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set { SetProperty(ref selectedStationItem, value); }
        }

        public MasterViewModel()
        {
            Title = "Master";

            StationItems = new ObservableCollection<StationItem>();
            Enumerable.Range(1, 50)
                .ForEach(x => StationItems.Add(new StationItem(x.ToString(), "dammy")));
        }

        public ICommand OpenWebCommand { get; }
    }
}


