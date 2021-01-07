namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	using System.Windows.Media;
	using System.Windows.Media.Media3D;
	using Microsoft.Research.DynamicDataDisplay.Common;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
	using Petzold.Media3D;

	public class StreamLineChart3D : VectorChartModel3DBase
	{
		#region Properties

		#region LinesCount

		public int LinesCount
		{
			get => (int)GetValue(LinesCountProperty);
			set => SetValue(LinesCountProperty, value);
		}

		public static readonly DependencyProperty LinesCountProperty = DependencyProperty.Register(
		  "LinesCount",
		  typeof(int),
		  typeof(StreamLineChart3D),
		  new FrameworkPropertyMetadata(50, OnLinesCountReplaced));

		private static void OnLinesCountReplaced(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			StreamLineChart3D owner = (StreamLineChart3D)d;
			owner.RebuildUI();
		}

		#endregion // LinesCount

		#region Pattern

		private PointSetPattern3D pattern = new RandomPattern3D();
		public PointSetPattern3D Pattern
		{
			get => pattern;
			set => pattern = value;
		}

		#endregion Pattern

		#region Bounds

		private Rect3D bounds = new Rect3D(new Point3D(-1, -1, -1), new Size3D(2, 2, 2));
		public Rect3D Bounds
		{
			get => bounds;
			set => bounds = value;
		}

		#endregion Bounds

		#endregion Properties

		private readonly ResourcePool<WirePolyline> linesPool = new ResourcePool<WirePolyline>();

		private Matrix3D matrix;
		protected override void RebuildUI()
		{
			linesPool.PutAll(Children.OfType<WirePolyline>());
			Children.Clear();

			if (DataSource == null)
				return;
			width = DataSource.Width;
			height = DataSource.Height;
			depth = DataSource.Depth;

			fieldWrapper = new UniformField3DWrapper(DataSource.Data, width, height, depth);

			matrix = Matrix3D.Identity;
			//matrix.Scale(new Vector3D(3, 3, 3));

			pattern.PointsCount = LinesCount;
			foreach (var point in pattern.GeneratePoints())
			{
				DrawLine(point);
			}
		}

		private WirePolyline CreatePolyline(IEnumerable<Point3D> points)
		{
			WirePolyline line;
			if (linesPool.IsEmpty)
			{
				line = new WirePolyline { Thickness = 1, Color = Colors.Red };
			}
			else
			{
				line = linesPool.Get();
			}

			line.Points = new Point3DCollection(points.Select(p => matrix.Transform(p)));

			return line;
		}

		private UniformField3DWrapper fieldWrapper;
		private int width;
		private int height;
		private int depth;
		protected void DrawLine(Point3D point)
		{
			// point was in cube [0..1]x[0..1]x[0..1], we are transforming it 
			// to cube [0..width]x[0..height]x[0..depth]

			Point3D start = point.TransformToBounds(bounds);

			int maxLength = 10 * Math.Max(width, Math.Max(height, depth));
			const int maxIterations = 400;
			Size3D boundsSize = new Size3D(1.0 / width, 1.0 / height, 1.0 / depth);

			Action<double, List<Point3D>> pointTracking = (direction, track) =>
			{
				var position01 = point;
				double length = 0;
				int i = 0;
				do
				{
					var K1 = fieldWrapper.GetVector(position01).DecreaseLength(boundsSize);
					var K2 = fieldWrapper.GetVector(position01 + (K1 / 2)).DecreaseLength(boundsSize);
					var K3 = fieldWrapper.GetVector(position01 + (K2 / 2)).DecreaseLength(boundsSize);
					var K4 = fieldWrapper.GetVector(position01 + K3).DecreaseLength(boundsSize);

					var shift = ((K1 + 2 * K2 + 2 * K3 + K4) / 6);
					if (shift.X.IsNaN() || shift.Y.IsNaN() || shift.Z.IsNaN())
						break;

					var next = position01 + direction * shift;
					Point3D viewportPoint = position01.TransformToBounds(bounds);
					track.Add(viewportPoint);

					position01 = next;
					length += shift.Length;
					i++;
				} while (length < maxLength && i < maxIterations);
			};

			var forwardTrack = new List<Point3D>();
			forwardTrack.Add(start);
			pointTracking(+1, forwardTrack);
			if (forwardTrack.Count > 1)
			{
				var forwardLine = CreatePolyline(forwardTrack);
				Children.Add(forwardLine);
			}

			var backwardTrack = new List<Point3D>();
			//backwardTrack.Add(start);
			pointTracking(-1, backwardTrack);
			if (backwardTrack.Count > 1)
			{
				var backwardLine = CreatePolyline(backwardTrack);
				Children.Add(backwardLine);
			}
		}
	}
}
