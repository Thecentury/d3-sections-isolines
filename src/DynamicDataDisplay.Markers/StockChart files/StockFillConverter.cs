namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Globalization;
	using System.Windows.Media;
	using Microsoft.Research.DynamicDataDisplay.Converters;

	public sealed class StockFillConverter : TwoValuesMultiConverter<double, double>
	{
		private Brush positiveFill;
		public Brush PositiveFill
		{
			get => positiveFill;
			set => positiveFill = value;
		}

		private Brush negativeFill;
		public Brush NegativeFill
		{
			get => negativeFill;
			set => negativeFill = value;
		}

		protected override object ConvertCore(double value1, double value2, Type targetType, object parameter, CultureInfo culture)
		{
			double open;
			double close;
			open = value1;
			close = value2;

			if (open < close)
				return positiveFill;
			return negativeFill;
		}
	}
}
