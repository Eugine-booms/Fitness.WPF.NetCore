using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness.WPF.NetCore.Converters
{
    internal static class LocalEx
    {
        public static double ExtractDouble(this object val)
        {
            double num = (val as double?) ?? double.NaN;
            if (!double.IsInfinity(num))
            {
                return num;
            }

            return double.NaN;
        }

        public static bool AnyNan(this IEnumerable<double> vals)
        {
            return vals.Any(new Func<double, bool>(double.IsNaN));
        }
    }
}
