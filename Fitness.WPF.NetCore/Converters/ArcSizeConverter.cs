using Boomsa.WPF.BaseLib.Converters.Base;

using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fitness.WPF.NetCore.Converters
{
    [ValueConversion(typeof(object[]), typeof(Size))]
    [MarkupExtensionReturnType(typeof(ArcSizeConverter))]
    public class ArcSizeConverter : MultiConverter
    {
       

        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is double && (double)values[0] > 0.0 && (values[1] is double && (double)values[1] > 0.0))
            {
                return new Size((double)values[0] / 2.0, (double)values[1] / 2.0);
            }
            return default(Point);
        }
        public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
