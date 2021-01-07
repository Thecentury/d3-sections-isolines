namespace DynamicDataDisplay.Markers.DataSources.ValueConverters
{
	using System;

	public static class Converter
	{
		public static GenericLambdaConverter<T, object> Create<T>(Func<T, object> lambda)
		{
			return new GenericLambdaConverter<T, object>(lambda);
		}
	}
}
