namespace DynamicDataDisplay.Markers.DataSources.ValueConvertersFactories
{
	using System;
	using System.Windows.Data;

	public abstract class ValueConverterFactory
	{
		public abstract IValueConverter TryBuildConverter(Type dataType, IValueConversionContext context);
	}
}
