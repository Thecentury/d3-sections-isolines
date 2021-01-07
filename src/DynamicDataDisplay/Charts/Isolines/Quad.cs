namespace Microsoft.Research.DynamicDataDisplay.Charts.Isolines
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;

	/// <summary>
	/// Represents quadrangle; its points are arranged by round in one direction.
	/// </summary>
	internal sealed class Quad
	{
		private readonly Point v00;
		public Point V00 => v00;

		private readonly Point v01;
		public Point V01 => v01;

		private readonly Point v10;
		public Point V10 => v10;

		private readonly Point v11;
		public Point V11 => v11;

		public Quad(Point v00, Point v01, Point v11, Point v10)
		{
			DebugVerify.IsNotNaN(v00);
			DebugVerify.IsNotNaN(v01);
			DebugVerify.IsNotNaN(v11);
			DebugVerify.IsNotNaN(v10);

			this.v00 = v00;
			this.v01 = v01;
			this.v10 = v10;
			this.v11 = v11;
		}

		/// <summary>
		/// Determines whether this quad contains the specified point.
		/// </summary>
		/// <param name="v">The point</param>
		/// <returns>
		/// 	<c>true</c> if quad contains the specified point; otherwise, <c>false</c>.
		/// </returns>
		public bool Contains(Point pt)
		{
			// breaking quad into 2 triangles, 
			// points contains in quad, if it contains in at least one half-triangle of it.
			return TriangleMath.TriangleContains(v00, v01, v11, pt) || TriangleMath.TriangleContains(v00, v10, v11, pt);
		}
	}
}
