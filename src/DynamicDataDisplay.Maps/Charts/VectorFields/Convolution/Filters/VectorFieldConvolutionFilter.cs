namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System;
	using System.Windows;

	public abstract class VectorFieldConvolutionFilter
	{
		public abstract int[] ApplyFilter(int[] pixels, int width, int height, Vector[,] field);

		public event EventHandler Changed;

		protected void RaiseChanged()
		{
			Changed.Raise(this);
		}
	}
}
