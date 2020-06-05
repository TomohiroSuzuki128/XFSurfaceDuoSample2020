using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        MasterViewModel masterViewModel;
        DetailsViewModel detailsViewModel;

        public MasterDetailPage()
        {
            InitializeComponent();
            masterPage.FindByName<CollectionView>("Stations").SelectionChanged += OnTitleSelected;
            detailsPagePushed = new DetailsPage();

            masterViewModel = masterPage.BindingContext as MasterViewModel;

            detailsViewModel = new DetailsViewModel();
            detailsPagePushed.BindingContext = detailsViewModel;
            detailsPage.BindingContext = detailsViewModel;

            SetDetailBindingContext();
        }

        void OnTitleSelected(object sender, SelectionChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"OnTitleSelected !!");

            if (e.CurrentSelection == null || e.CurrentSelection.Count == 0)
                return;

            masterViewModel.ChangeSelectedStationItem(e.CurrentSelection[0] as StationItem);
            SetupViews();            
        }

        void SetDetailBindingContext([CallerMemberName] string memberName = "")
        {
            System.Diagnostics.Debug.WriteLine($"CallerMemberName = {memberName}");
            System.Diagnostics.Debug.WriteLine($"ChangeSelectedStationItem !!");

            detailsViewModel.ChangeSelectedStationItem(masterViewModel.SelectedStationItem);
        }

        async void SetupViews([CallerMemberName] string memberName = "")
        {
            System.Diagnostics.Debug.WriteLine($"CallerMemberName = {memberName}");
            System.Diagnostics.Debug.WriteLine($"IsSpanned = {IsSpanned}");
            System.Diagnostics.Debug.WriteLine($"IsLandscape = {DualScreenInfo.Current.IsLandscape}");

            if (IsSpanned && !DualScreenInfo.Current.IsLandscape)
                SetDetailBindingContext();

            if (detailsPage.BindingContext == null)
                return;

            if (!IsSpanned)
            {
                System.Diagnostics.Debug.WriteLine($"PushAsync !!");
                if (!Navigation.NavigationStack.Contains(detailsPagePushed))
                {
                    await Navigation.PushAsync(detailsPagePushed);
                }
            }
        }

        protected override void OnAppearing()
        {
            //if (!IsSpanned)
            //    (masterPage.BindingContext as MasterViewModel).SelectedStationItem = null;

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