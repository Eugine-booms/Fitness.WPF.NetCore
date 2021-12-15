using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Fitness.WPF.NetCore.Converters
{
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
            double num = values[0].ExtractDouble();
            double num2 = values[1].ExtractDouble();
            double num3 = values[2].ExtractDouble();
            double num4 = values[3].ExtractDouble();
            if (new double[4]
            {
                num,
                num2,
                num3,
                num4
            }.AnyNan())
            {
                return Binding.DoNothing;
            }

            if (values.Length == 5)
            {
                double num5 = values[4].ExtractDouble();
                if (!double.IsNaN(num5) && num5 > 0.0)
                {
                    num2 = (num4 - num3) * num5;
                }
            }

            double num6 = (num4 <= num3) ? 1.0 : ((num2 - num3) / (num4 - num3));
            if (object.Equals(parameter, "MidPoint"))
            {
                num6 /= 2.0;
            }

            double num7 = 360.0 * num6 * (Math.PI / 180.0);
            Point point = new Point(num / 2.0, num / 2.0);
            double num8 = num / 2.0;
            double num9 = Math.Cos(num7) * num8;
            double num10 = Math.Sin(num7) * num8;
            return new Point(point.X + num10, point.Y - num9);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
