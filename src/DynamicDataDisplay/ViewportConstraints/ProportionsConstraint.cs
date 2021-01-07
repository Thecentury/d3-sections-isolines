namespace Microsoft.Research.DynamicDataDisplay.ViewportConstraints
{
	using System;
	using System.Windows;

	public sealed class ProportionsConstraint : ViewportConstraint
	{
		private double widthToHeightRatio = 1;
		public double WidthToHeightRatio
		{
			get => widthToHeightRatio;
			set
			{
				if (widthToHeightRatio != value)
				{
					widthToHeightRatio = value;
					RaiseChanged();
				}
			}
		}

		public override DataRect Apply(DataRect oldDataRect, DataRect newDataRect, Viewport2D viewport)
		{
			double ratio = newDataRect.Width / newDataRect.Height;
			double coeff = Math.Sqrt(ratio);

			double newWidth = newDataRect.Width / coeff;
			double newHeight = newDataRect.Height * coeff;

			Point center = newDataRect.GetCenter();
			DataRect res = DataRect.FromCenterSize(center, newWidth, newHeight);
			return res;
		}
	}
}
