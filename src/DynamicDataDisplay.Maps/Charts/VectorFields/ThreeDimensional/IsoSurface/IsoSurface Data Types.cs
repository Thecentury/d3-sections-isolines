namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows.Media.Media3D;

	internal struct IsoSurfaceVertex
	{
		public Vector3D Position;
		public Vector3D Normal;
	}

	internal struct IsoSurfaceIndex
	{
		public int EdgeIndex;
		public int ListPosition;
	}
}
