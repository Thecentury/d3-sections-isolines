namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System;
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Media.Media3D;
	using Microsoft.Research.DynamicDataDisplay.SampleDataSources;
	using Petzold.Media3D;

	public class PotentialFieldChart3D : ModelVisual3D
	{
		public PotentialField3D Field { get; set; }

		protected override void OnVisualParentChanged(DependencyObject oldParent)
		{
			base.OnVisualParentChanged(oldParent);

			Children.Clear();

			foreach (var point in Field.Points)
			{
				Sphere sphere = new Sphere
				{
					Center = point.Position,
					Radius = Math.Pow(Math.Log(1 + Math.Abs(point.Potential)), 0.2) - 1,
					Material = new DiffuseMaterial { Brush = point.Potential > 0 ? Brushes.Red : Brushes.Blue }
				};
				Children.Add(sphere);
			}
		}
	}
}
