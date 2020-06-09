using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSurfaceDuoSample2020.ViewModels;

namespace XFSurfaceDuoSample2020
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Master : StackLayout
    {
        public Master()
        {
            InitializeComponent();
            BindingContext = new MasterViewModel(new DetailsViewModel());
        }
    }
}