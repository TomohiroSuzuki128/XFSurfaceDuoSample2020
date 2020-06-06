using System;
using System.ComponentModel;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XFSurfaceDuoSample2020;
using XFSurfaceDuoSample2020.Droid.CustomRenderers;

[assembly: ExportRenderer(typeof(ExPicker), typeof(ExPickerRenderer))]
namespace XFSurfaceDuoSample2020.Droid.CustomRenderers
{
    public class ExPickerRenderer : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
    {
        ExPicker picker = null;
        public ExPickerRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                picker = Element as ExPicker;
                UpdatePickerPlaceholder();
                if (picker.SelectedIndex <= -1)
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (picker != null)
            {
                if (e.PropertyName.Equals(ExPicker.PlaceholderProperty.PropertyName))
                {
                    UpdatePickerPlaceholder();
                }
            }
        }

        protected override void UpdatePlaceHolderText()
        {
            UpdatePickerPlaceholder();
        }

        void UpdatePickerPlaceholder()
        {
            if (picker == null)
                picker = Element as ExPicker;
            if (picker.Placeholder != null)
                Control.Hint = picker.Placeholder;
        }
    }
}
