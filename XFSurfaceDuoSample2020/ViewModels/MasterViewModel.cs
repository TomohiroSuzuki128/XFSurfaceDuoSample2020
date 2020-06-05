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
    public class MasterViewModel : ViewModelBase
    {

        public DetailsViewModel DetailsViewModel { get; private set; }

        public ObservableCollection<StationItem> StationItems { get; set; }
        public ObservableCollection<LineItem> LineItems { get; set; }

        MockLineItemDataStore mockLineItemDataStore = new MockLineItemDataStore();
        MockStationItemDataStore mockStationItemDataStore = new MockStationItemDataStore();

        LineItem selectedLineItem;
        public LineItem SelectedLineItem
        {
            get { return selectedLineItem; }
            set { SetProperty(ref selectedLineItem, value); }
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
            (await mockStationItemDataStore.GetItemsAsync()).ForEach(x => StationItems.Add(x));
            SelectedStationItem = StationItem.Empty;

            SelectStationCommand = new Command(() => OnTitleSelected());
        }

        void ChangeSelectedStationItem(StationItem selectedStationItem) =>
             SelectedStationItem = DetailsViewModel.SelectedStationItem = selectedStationItem;

        void OnTitleSelected()
        {
            System.Diagnostics.Debug.WriteLine($"OnTitleSelected !!");

            ChangeSelectedStationItem(SelectedStationItem);
            SetupViewsAction?.Invoke();
        }
        
    }
}


