using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.DualScreen;
using Xamarin.Forms.Xaml;
using XFSurfaceDuoSample2020.Models;
using XFSurfaceDuoSample2020.ViewModels;

namespace XFSurfaceDuoSample2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPage
    {
        bool IsSpanned => DualScreenInfo.Current.SpanMode != TwoPaneViewMode.SinglePane;
        DetailsPage detailsPagePushed;

        public MasterDetailPage()
        {
            InitializeComponent();
            masterPage.FindByName<CollectionView>("Stations").SelectionChanged += OnTitleSelected;
            detailsPagePushed = new DetailsPage();
        }

        void OnTitleSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            SetDetailBindingContext();
            SetupViews();            
        }

        void SetDetailBindingContext()
        {
            var selectedStationItem = (masterPage.BindingContext as MasterViewModel).SelectedStationItem ?? 
                ((masterPage.BindingContext as MasterViewModel)
                .StationItems as IList<StationItem>)[0];
            detailsPagePushed.BindingContext = new DetailViewModel(selectedStationItem);
            detailsPage.BindingContext = new DetailViewModel(selectedStationItem);
        }

        async void SetupViews()
        {
            if (IsSpanned && !DualScreenInfo.Current.IsLandscape)
                SetDetailBindingContext();

            if (detailsPage.BindingContext == null)
                return;

            if (!IsSpanned)
            {
                if (!Navigation.NavigationStack.Contains(detailsPagePushed))
                {
                    await Navigation.PushAsync(detailsPagePushed);
                }
            }

        }

        protected override void OnAppearing()
        {
            if (!IsSpanned)
                (masterPage.BindingContext as MasterViewModel).SelectedStationItem = null;

            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        void OnFormsWindowPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DualScreenInfo.Current.SpanMode) ||
                e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
            {
                SetupViews();
            }
        }

    }
}