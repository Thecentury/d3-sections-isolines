using DataSource = Microsoft.Research.DynamicDataDisplay.DataSources.IDataSource2D<System.Windows.Vector>;

namespace Microsoft.Research.DynamicDataDisplay.SampleDataSources
{
	using System;
	using System.Linq;
	using System.Windows;
	using System.Windows.Media.Media3D;
	using Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional;

	public static class VectorField2D
	{
		private static DataSource CreateVectorField(int width, int height, Vector[,] data)
		{
			double[] xs = Enumerable.Range(0, width).Select(i => (double)i).ToArray();
			double[] ys = Enumerable.Range(0, height).Select(i => (double)i).ToArray();

			return new NonUniformDataSource2D<Vector>(xs, ys, data);
		}

		public static DataSource Create(Func<int, int, Point> gridFunc, Func<int, int, Vector> dataFunc, int width = 100, int height = 100)
		{
			if (gridFunc == null)
				throw new ArgumentNullException("gridFunc");
			if (dataFunc == null)
				throw new ArgumentNullException("dataFunc");
			if (width < 2)
				throw new ArgumentOutOfRangeException("width");
			if (height < 2)
				throw new ArgumentOutOfRangeException("height");

			Point[,] grid = new Point[width, height];
			Vector[,] data = new Vector[width, height];

			for (int ix = 0; ix < width; ix++)
			{
				for (int iy = 0; iy < height; iy++)
				{
					grid[ix, iy] = gridFunc(ix, iy);
					data[ix, iy] = dataFunc(ix, iy);
				}
			}

			WarpedDataSource2D<Vector> dataSource = new WarpedDataSource2D<Vector>(data, grid);
			return dataSource;
		}

		public static DataSource CreateCheckerboard(int width = 100, int height = 100)
		{
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
			{
				var result = (x / 40) % 2 - (y / 40) % 2 == 0 ? new Vector(x + 1, 0) : new Vector(0, y + 1);
				return result;
			});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreateCircularField(int width = 100, int height = 100)
		{
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
			{
				Vector3D center = new Vector3D(width / 2f, height / 2f, 0);
				Vector3D up = new Vector3D(0, 0, 1);
				Vector3D vec = center - new Vector3D(x, y, 0);
				Vector3D tangent = Vector3D.CrossProduct(vec, up);
				Vector value = new Vector(tangent.X, tangent.Y);
				//if (value.X != 0 || value.Y != 0)
				//    value.Normalize();

				return value;
			});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreateCircularField2(int width = 100, int height = 100)
		{
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
				{
					Vector result;

					double xc = x - width / 2;
					double yc = y - height / 2;
					if (xc != 0)
					{
						double beta = Math.Sqrt(1.0 / (1 + yc * yc / (xc * xc)));
						double alpha = -beta * yc / xc;
						result = new Vector(alpha, beta);
					}
					else
					{
						double alpha = Math.Sqrt(1.0 / (1 + xc * xc / (yc * yc)));
						double beta = -alpha * xc / yc;
						result = new Vector(alpha, beta);
					}

					if (Double.IsNaN(result.X))
					{
						result = new Vector(0, 0);
					}

					return result;
				});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreateTangentPotentialField(int width = 200, int height = 200, params PotentialPoint[] points)
		{
			var potentialField = new PotentialField();
			potentialField.AddPoints(points);
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
			{
				return potentialField.GetTangentVector(new Point(x, y));
			});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreateTangentPotentialField(PotentialField field, int width = 200, int height = 200)
		{
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
			{
				return field.GetTangentVector(new Point(x, y));
			});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreatePotentialField(int width = 100, int height = 100, params PotentialPoint[] points)
		{
			var potentialField = new PotentialField();
			potentialField.AddPoints(points);
			var vectorArray = DataSource2DHelper.CreateVectorData(width, height, (x, y) =>
			{
				return potentialField.GetVector(new Point(x, y));
			});

			return CreateVectorField(width, height, vectorArray);
		}

		public static DataSource CreateDynamicTangentPotentialField(PotentialField field, int width = 200, int height = 200)
		{
			return new SampleUniformPotentialFieldDataSource(field, width, height);
		}
	}
}
