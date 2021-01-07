namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Globalization;
	using System.Windows.Data;
	using System.Windows.Media;

	public class NegativeRotateTransformConverter : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			RotateTransform transform = value as RotateTransform;

			if (transform != null)
			{
				return new RotateTransform(-transform.Angle);
			}

			return null;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
