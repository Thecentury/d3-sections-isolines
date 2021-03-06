﻿using DataSource = Microsoft.Research.DynamicDataDisplay.DataSources.IDataSource2D<System.Windows.Vector>;

namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System;
	using System.Windows;
	using System.Windows.Controls;
	using System.Windows.Media;
	using System.Windows.Media.Media3D;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
	using Microsoft.Research.DynamicDataDisplay.DataSources.MultiDimensional;
	using Microsoft.Research.DynamicDataDisplay.ThreeDimensional;

	/// <summary>
	/// Interaction logic for VectorBasedMeshChart.xaml
	/// </summary>
	public partial class VectorBasedMeshChart : UserControl
	{
		public VectorBasedMeshChart()
		{
			InitializeComponent();
		}

		#region Properties

		public DataSource DataSource
		{
			get => (DataSource)GetValue(DataSourceProperty);
			set => SetValue(DataSourceProperty, value);
		}

		public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register(
		  "DataSource",
		  typeof(DataSource),
		  typeof(VectorBasedMeshChart),
		  new FrameworkPropertyMetadata(null, OnDataSourceReplaced));

		private static void OnDataSourceReplaced(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			VectorBasedMeshChart owner = (VectorBasedMeshChart)d;
			owner.OnDataSourceReplaced((DataSource)e.OldValue, (DataSource)e.NewValue);
		}

		private void OnDataSourceReplaced(DataSource prevDataSource, DataSource currDataSource)
		{
			heightDataSource = null;
			if (prevDataSource != null)
			{
				prevDataSource.Changed -= OnDataSourceChanged;
			}
			if (currDataSource != null)
			{
				currDataSource.Changed += OnDataSourceChanged;
				heightDataSource = new VectorToMagnitudeDataSource(currDataSource);
			}

			UpdateUI();
		}

		private VectorToMagnitudeDataSource heightDataSource;
		private readonly MeshGeometry3D meshGeometry = new MeshGeometry3D();

		private void OnDataSourceChanged(object sender, EventArgs e)
		{
			UpdateUI();
		}

		private void UpdateUI()
		{
			if (heightDataSource == null)
				return;

			var minMax = heightDataSource.Data.GetMinMax();
			double min = minMax.Min;
			double max = minMax.Max;
			double length = minMax.GetLength();
			var height = heightDataSource.Height;

			PointCollection textureCoordinates;
			Point3DCollection vertices;
			Int32Collection indices;
			MeshHelper.BuildMeshData((ix, iy) => -Math.Pow(((heightDataSource.Data[ix, height - 1 - iy] - min) / length), 0.1) / 2, heightDataSource.Width, heightDataSource.Height,
				out vertices, out textureCoordinates, out indices);

			meshGeometry.Positions = vertices;
			meshGeometry.TextureCoordinates = textureCoordinates;
			meshGeometry.TriangleIndices = indices;

			viewport2dVisual3d.Geometry = meshGeometry;
		}

		#endregion

		public ChartPlotter Plotter => plotter;
	}
}
