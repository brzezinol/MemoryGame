using System;
using System.Globalization;
using Xamarin.Forms;

namespace MemoryGame
{
    public class BoolToColorConverter : BindableObject, IValueConverter
    {
        public Color TrueColor {
            get { return (Color)GetValue(TrueColorProperty); }
            set { SetValue(TrueColorProperty, value); }
        }

        public static BindableProperty TrueColorProperty = BindableProperty.Create(nameof(TrueColor), typeof(Color), typeof(BoolToColorConverter), null);

        public Color FalseColor {
            get { return (Color)GetValue(FalseColorProperty); }
            set { SetValue(FalseColorProperty, value); }
        }

        public static BindableProperty FalseColorProperty = BindableProperty.Create(nameof(FalseColor), typeof(Color), typeof(BoolToColorConverter), null);


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value == null) return null;

            if((bool)value)
                return TrueColor;
            
            return FalseColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
