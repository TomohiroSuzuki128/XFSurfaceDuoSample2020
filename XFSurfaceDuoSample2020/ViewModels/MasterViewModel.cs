using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using XFSurfaceDuoSample2020.Models;
using XFSurfaceDuoSample2020.Services;

namespace XFSurfaceDuoSample2020.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {

        public DetailsViewModel DetailsViewModel { get; private set; }

        public ObservableCollection<StationItem> StationItems { get; set; }
        public ObservableCollection<LineItem> LineItems { get; set; }

        ILineDataStore mockLineItemDataStore = new MockLineDataStore();
        IStationDataStore mockStationItemDataStore = new MockStationDataStore();

        LineItem selectedLineItem;
        public LineItem SelectedLineItem
        {
            get { return selectedLineItem; }
            set {
                SetProperty(ref selectedLineItem, value);
                SelectLineCommand?.Execute(null);
            }
        }

        StationItem selectedStationItem;
        public StationItem SelectedStationItem
        {
            get { return selectedStationItem; }
            set { SetProperty(ref selectedStationItem, value); }
        }

        public ICommand SelectLineCommand { private set; get; }
        public ICommand SelectStationCommand { private set; get; }

        public Action SetupViewsAction { get; set; }

        public MasterViewModel(DetailsViewModel detailsViewModel)
        {
            Initialize();
            DetailsViewModel = detailsViewModel;
        }

        async void Initialize()
        {
            Title = "Master";

            LineItems = new ObservableCollection<LineItem>();
            (await mockLineItemDataStore.GetItemsAsync()).ForEach(x => LineItems.Add(x));
            SelectedLineItem = LineItem.Empty;

            StationItems = new ObservableCollection<StationItem>();
            (await mockStationItemDataStore.GetItemsAsync(SelectedLineItem.ID)).ForEach(x => StationItems.Add(x));
            SelectedStationItem = StationItem.Empty;

            SelectLineCommand = new Command(async () => await OnLineSelected());
            SelectStationCommand = new Command(() => OnStationSelected());
        }

        async Task OnLineSelected() =>
            await ChangeStationList(SelectedLineItem);

        void OnStationSelected()
        {
            ChangeSelectedStationItem(SelectedStationItem);
            SetupViewsAction?.Invoke();
        }

        async Task ChangeStationList(LineItem selectedLineItem)
        {
            StationItems.Clear();
            (await mockStationItemDataStore.GetItemsAsync(selectedLineItem.ID)).ForEach(x => StationItems.Add(x));
            SelectedStationItem = StationItem.Empty;
        }

        void ChangeSelectedStationItem(StationItem selectedStationItem) =>
             SelectedStationItem = DetailsViewModel.SelectedStationItem = selectedStationItem;

    }
}
