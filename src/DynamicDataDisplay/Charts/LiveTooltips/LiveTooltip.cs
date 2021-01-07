﻿namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media;

	public class LiveToolTip : ContentControl
	{
		static int nameCounter;
		static LiveToolTip()
		{
			var thisType = typeof(LiveToolTip);

			DefaultStyleKeyProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(thisType));
			FocusableProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(false));
			IsHitTestVisibleProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(false));
			BackgroundProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(Brushes.White));
			OpacityProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(1.0));
			BorderBrushProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(Brushes.DarkGray));
			BorderThicknessProperty.OverrideMetadata(thisType, new FrameworkPropertyMetadata(new Thickness(1.0)));
		}

		public LiveToolTip()
		{
			Name = "Microsoft_Research_Dynamic_Data_Display_Charts_LiveToolTip_" + nameCounter;
			nameCounter++;
		}

		#region Properties

		public FrameworkElement Owner
		{
			get => (FrameworkElement)GetValue(OwnerProperty);
			set => SetValue(OwnerProperty, value);
		}

		public static readonly DependencyProperty OwnerProperty = DependencyProperty.Register(
		  "Owner",
		  typeof(FrameworkElement),
		  typeof(LiveToolTip),
		  new FrameworkPropertyMetadata(null));

		#endregion // end of Properties
	}
}
