using Boomsa.WPF.BaseLib.Converters.Base;

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
    [ValueConversion(typeof(object []), typeof(Point))]
    [MarkupExtensionReturnType(typeof(StartPointConverter))]
    public class StartPointConverter : MultiConverter
    {
        
        public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Point point = new Point(0, 0);
            if (!(values[0] is double width)) 
                return point;
            point.X = width;
            if (!(values[1] is double height)) 
                return point;
            point.Y = height;
            point.X = point.X / 2 ;
            return point;
        }
    }
}
