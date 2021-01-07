﻿namespace Microsoft.Research.DynamicDataDisplay.Converters
{
	using System;
	using System.Globalization;
	using System.Windows.Data;
	using System.Windows.Media;

	public sealed class BrushHSBConverter : IValueConverter
	{
		private double lightnessDelta = 1.0;
		public double LightnessDelta
		{
			get => lightnessDelta;
			set => lightnessDelta = value;
		}

		private double saturationDelta = 1.0;
		public double SaturationDelta
		{
			get => saturationDelta;
			set => saturationDelta = value;
		}

		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			SolidColorBrush brush = value as SolidColorBrush;
			if (brush != null)
			{
				SolidColorBrush result = brush.ChangeLightness(lightnessDelta).ChangeSaturation(saturationDelta);
				return result;
			}

			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
