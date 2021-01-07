﻿namespace Microsoft.Research.DynamicDataDisplay
{
	using System;
	using System.Windows;

	public sealed class ExtendedPropertyChangedEventArgs : EventArgs
	{
		public string PropertyName { get; set; }
		public object OldValue { get; set; }
		public object NewValue { get; set; }

		public static ExtendedPropertyChangedEventArgs FromDependencyPropertyChanged(DependencyPropertyChangedEventArgs e)
		{
			return new ExtendedPropertyChangedEventArgs { PropertyName = e.Property.Name, NewValue = e.NewValue, OldValue = e.OldValue };
		}
	}
}
