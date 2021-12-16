using Microsoft.VisualBasic;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fitness.WPF.NetCore.Converters
{
    [ValueConversion(typeof(object[]), typeof(string))]
    [MarkupExtensionReturnType(typeof(TextBoxForCircleStatusBar))]
    class TextBoxForCircleStatusBar : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(values[0] is double value)) return "value";
            if (!(values[1] is double minimum)) return "minimum";
            if (!(values[2] is double maximum)) return "minimum";
            return $"{value} / {maximum}";
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
