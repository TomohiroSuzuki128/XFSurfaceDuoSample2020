using System;
using System.Collections.Generic;
using System.ComponentModel;
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

            detailsPagePushed = new DetailsPage();

            masterViewModel = masterPage.BindingContext as MasterViewModel;
            masterViewModel.SetupViewsAction = () => SetupViews();

            detailsViewModel = masterViewModel.DetailsViewModel;
            detailsPagePushed.BindingContext = detailsViewModel;
            detailsPage.BindingContext = detailsViewModel;
        }

        async void SetupViews()
        {
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
            DualScreenInfo.Current.PropertyChanged += OnFormsWindowPropertyChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DualScreenInfo.Current.PropertyChanged -= OnFormsWindowPropertyChanged;
        }

        void OnFormsWindowPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(DualScreenInfo.Current.SpanMode) ||
                e.PropertyName == nameof(DualScreenInfo.Current.IsLandscape))
            {
                SetupViews();
            }
        }

    }
}