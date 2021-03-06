﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;
	using System.Windows.Controls;
	using Microsoft.Research.DynamicDataDisplay.Charts.Axes;

	/// <summary>
	/// Represents a simple label provider for double ticks, which simply returns result of .ToString() method, called for rounded ticks.
	/// </summary>
	public class ToStringLabelProvider : NumericLabelProviderBase
	{
		public override UIElement[] CreateLabels(ITicksInfo<double> ticksInfo)
		{
			var ticks = ticksInfo.Ticks;

			Init(ticks);

			UIElement[] res = new UIElement[ticks.Length];
			LabelTickInfo<double> tickInfo = new LabelTickInfo<double> { Info = ticksInfo.Info };
			for (int i = 0; i < res.Length; i++)
			{
				tickInfo.Tick = ticks[i];
				tickInfo.Index = i;

				string labelText = GetString(tickInfo);

				TextBlock label = (TextBlock)GetResourceFromPool();
				if (label == null)
				{
					label = new TextBlock();
				}

				label.Text = labelText;
				label.ToolTip = ticks[i].ToString();

				res[i] = label;

				ApplyCustomView(tickInfo, label);
			}
			return res;
		}
	}
}
