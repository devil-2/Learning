using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using BasicApp.ViewModels.Factories;
using BasicApplication.Domain.Models;

namespace BasicApp.Converters
{
    public class ObjectToAdminMenuListFactoryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((IEnumerable<Menu>)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
