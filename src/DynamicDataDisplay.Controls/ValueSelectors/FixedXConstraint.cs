namespace Microsoft.Research.DynamicDataDisplay.Controls
{
	using Microsoft.Research.DynamicDataDisplay.ViewportConstraints;

	internal sealed class FixedXConstraint : ViewportConstraint
	{
		public override DataRect Apply(DataRect previousDataRect, DataRect proposedDataRect, Viewport2D viewport)
		{
			return DataRect.Create(proposedDataRect.XMin, 0, proposedDataRect.XMax, 1);
		}
	}
}
