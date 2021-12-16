using Boomsa.WPF.BaseLib.Converters.Base;

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Fitness.WPF.NetCore.Converters
{
    /// <summary>
    /// выполняет преобразование вида f(x)=K*x;
    /// </summary>
    [ValueConversion(typeof(double), typeof(double))]
    [MarkupExtensionReturnType(typeof(RatioConverter))]
    internal class RatioConverter : Converter
    {
        public RatioConverter(double k) => K = k;

        public RatioConverter() { }
        [ConstructorArgument("K")]
        public double K { get; set; } = 1;
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var x = System.Convert.ToDouble(value, culture);
            return K * x;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            if (string.IsNullOrEmpty(value as string)) return 0;
            var y = System.Convert.ToDouble(value, culture);
            return y / K;
        }

    }
}
