namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using System.Globalization;
	using Microsoft.Research.DynamicDataDisplay.Converters;

	internal sealed class LegendTopButtonToIsEnabledConverter : GenericValueConverter<double>
	{
		public override object ConvertCore(double value, Type targetType, object parameter, CultureInfo culture)
		{
			double verticalOffset = value;

			return verticalOffset > 0;
		}
	}
}
