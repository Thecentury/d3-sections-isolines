﻿namespace DynamicDataDisplay.Markers.DataSources.ValueConvertersFactories
{
	using System;
	using System.Collections.ObjectModel;
	using System.Windows.Data;
	using Microsoft.Research.DynamicDataDisplay;

	public sealed class ValueConverterFactoriesStore
	{
		private ValueConverterFactoriesStore()
		{
			RegisterFactory(new DateTimeValueConverterFactory());
			RegisterFactory(new CharValueConverterFactory());
		}

		private static readonly ValueConverterFactoriesStore current = new ValueConverterFactoriesStore();

		public static ValueConverterFactoriesStore Current => current;

		public void RegisterFactory(ValueConverterFactory factory)
		{
			if (factory == null)
				throw new ArgumentNullException("factory");

			factories.Add(factory);
		}

		private readonly ObservableCollection<ValueConverterFactory> factories = new ObservableCollection<ValueConverterFactory>();

		public IValueConverter TryBuildConverter(Type dataType, Plotter plotter)
		{
			IValueConverter result = null;

			IValueConversionContext context = new ValueConversionContext { Plotter = plotter };
			foreach (var factory in factories)
			{
				result = factory.TryBuildConverter(dataType, context);
				if (result != null)
					return result;
			}

			return result;
		}
	}
}
