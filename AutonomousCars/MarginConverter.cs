using System;
using System.Windows;
using System.Windows.Data;

namespace AutonomousCars
{
    public class MarginConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values[0] == null || values[1] == null) return null;

            var margin = new Thickness
            {
                Left = 700 - (int)values[0] * 45,
                Right = 0,
                Top = 500 - (float)values[1],
                Bottom = 0
            };

            return margin;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
