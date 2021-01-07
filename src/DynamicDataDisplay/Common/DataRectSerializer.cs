﻿namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System.Globalization;
	using System.Windows.Markup;

	public sealed class DataRectSerializer : ValueSerializer
	{
		public override bool CanConvertFromString(string value, IValueSerializerContext context)
		{
			return true;
		}

		public override bool CanConvertToString(object value, IValueSerializerContext context)
		{
			return value is DataRect;
		}

		public override object ConvertFromString(string value, IValueSerializerContext context)
		{
			if (value != null)
			{
				return DataRect.Parse(value);
			}
			return base.ConvertFromString(value, context);
		}

		public override string ConvertToString(object value, IValueSerializerContext context)
		{
			if (value is DataRect)
			{
				DataRect rect = (DataRect)value;
				return rect.ConvertToString(null, CultureInfo.GetCultureInfo("en-us"));
			}
			return base.ConvertToString(value, context);
		}
	}
}
