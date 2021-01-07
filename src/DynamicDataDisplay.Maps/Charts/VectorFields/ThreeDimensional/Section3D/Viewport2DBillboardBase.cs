namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Media.Media3D;

	public abstract class Viewport2DBillboardBase : BillboardChartBase
	{
		protected readonly Viewport2DVisual3D viewport2DVisual = new Viewport2DVisual3D();
		protected readonly MeshGeometry3D meshGeometry = new MeshGeometry3D();

		protected readonly double zDelta = 0.001;

		protected Viewport2DBillboardBase()
		{
			Material material = new DiffuseMaterial(Brushes.White);
			Viewport2DVisual3D.SetIsVisualHostMaterial(material, true);
			material.Freeze();

			viewport2DVisual.Material = material;

			Children.Add(viewport2DVisual);

			meshGeometry.TextureCoordinates.Add(new Point(0, 1));
			meshGeometry.TextureCoordinates.Add(new Point(1, 1));
			meshGeometry.TextureCoordinates.Add(new Point(0, 0));
			meshGeometry.TextureCoordinates.Add(new Point(1, 0));

			meshGeometry.TriangleIndices.Add(0);
			meshGeometry.TriangleIndices.Add(1);
			meshGeometry.TriangleIndices.Add(3);
			meshGeometry.TriangleIndices.Add(0);
			meshGeometry.TriangleIndices.Add(3);
			meshGeometry.TriangleIndices.Add(2);

			viewport2DVisual.Geometry = meshGeometry;
		}

		#region Properties

		public Visual Visual
		{
			get => (Visual)GetValue(VisualProperty);
			set => SetValue(VisualProperty, value);
		}

		public static readonly DependencyProperty VisualProperty = DependencyProperty.Register(
		  "Visual",
		  typeof(Visual),
		  typeof(Viewport2DBillboardBase),
		  new FrameworkPropertyMetadata(null, OnVisualChanged));

		private static void OnVisualChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			Viewport2DBillboardBase owner = (Viewport2DBillboardBase)d;
			Visual visual = (Visual)e.NewValue;
			owner.viewport2DVisual.Visual = visual;
			//owner.backViewport2DVisual.Visual = visual;
		}

		#endregion Properties
	}
}
