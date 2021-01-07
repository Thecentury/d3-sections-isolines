namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Windows;

	public static class StockItemStyles
	{
		private static Style candleStick;
		public static Style CandleStick
		{
			get
			{
				if (candleStick == null)
				{
					ResourceDictionary genericDict = (ResourceDictionary)Application.LoadComponent(new Uri("/DynamicDataDisplay.Markers;component/Themes/Generic.xaml", UriKind.Relative));
					candleStick = (Style)genericDict["candleStickStyle"];
				}
				return candleStick;
			}
		}

		private static Style defaultStyle;
		public static Style Default
		{
			get
			{
				if (defaultStyle == null)
				{
					ResourceDictionary genericDict = (ResourceDictionary)Application.LoadComponent(new Uri("/DynamicDataDisplay.Markers;component/Themes/Generic.xaml", UriKind.Relative));
					defaultStyle = (Style)genericDict[typeof(StockItem)];
				}
				return defaultStyle;
			}
		}
	}
}
