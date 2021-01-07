namespace DynamicDataDisplay.Markers.DataSources.ValueConverters
{
	using System;
	using System.Globalization;
	using System.Windows.Data;

	public sealed class LambdaMultiConverter : IMultiValueConverter
	{
		private Func<object[], object> conversion;
		public LambdaMultiConverter(Func<object[], object> conversion)
		{
			if (conversion == null)
				throw new ArgumentNullException("conversion");

			this.conversion = conversion;
		}

		#region IMultiValueConverter Members

		public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
		{
			return conversion(values);
		}

		public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
