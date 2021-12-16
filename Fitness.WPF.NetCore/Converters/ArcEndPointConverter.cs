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
    [ValueConversion(typeof(object[]), typeof(Point))]
    [MarkupExtensionReturnType(typeof(ArcEndPointConverter))]
    class ArcEndPointConverter  : IMultiValueConverter
    {
        //
        // Сводка:
        //     CircularProgressBar draws two arcs to support a full circle at 100 %. With one
        //     arc at 100 % the start point is identical the end point, so nothing is drawn.
        //     Midpoint at half of current percentage is the endpoint of the first arc and the
        //     start point of the second arc.
        public const string ParameterMidPoint = "MidPoint";

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double ActualWidth = values[0].ExtractDouble();
            double Value = values[1].ExtractDouble();
            double Minimum = values[2].ExtractDouble();
            double Maximum = values[3].ExtractDouble();
            if (new double[4]
            {
                ActualWidth,
                Value,
                Minimum,
                Maximum
            }.AnyNan())
            {
                return Binding.DoNothing;
            }


            double val = (Maximum <= Minimum) ? 1.0 : ((Value - Minimum) / (Maximum - Minimum));
            if (object.Equals(parameter, "MidPoint")&& val >=0.5)
                return new Point(ActualWidth / 2.0, 0);
            
                double valueRad = 360.0 * val * (Math.PI / 180.0);
                Point point = new Point(ActualWidth / 2.0, ActualWidth / 2.0);
                double radius = ActualWidth / 2.0;
                double num9 = Math.Sin(valueRad) * radius;
                double num10 = Math.Cos(valueRad) * radius;
                var pointResult = new Point(point.X - num9, point.Y + num10);
                return pointResult;
            
            
            
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
