using System;
using Xamarin.Forms;

namespace XFSurfaceDuoSample2020.Controls
{
    public class PLPicker : Picker
    {

        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(
            propertyName: nameof(Placeholder),
            returnType: typeof(string),
            declaringType: typeof(string),
            defaultValue: string.Empty);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

    }
}
