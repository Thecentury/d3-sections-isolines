namespace DynamicDataDisplay.Markers.DataSources.ValueConvertersFactories
{
	using System;
	using System.Windows.Data;
	using Microsoft.Research.DynamicDataDisplay.Converters;

	internal sealed class CharValueConverterFactory : ValueConverterFactory
	{
		public override IValueConverter TryBuildConverter(Type dataType, IValueConversionContext context)
		{
			if (dataType == typeof(char))
			{
				return new GenericValueConverter<char>(c => (double)c);
			}
			return null;
		}
	}
}
