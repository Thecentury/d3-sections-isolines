namespace Microsoft.Research.DynamicDataDisplay.Charts
{
	using System;
	using System.Collections.Generic;
	using System.Windows;
	using global::DynamicDataDisplay.Markers;
	using Microsoft.Research.DynamicDataDisplay.Filters;
	using Microsoft.Research.DynamicDataDisplay.Markers;
	using Microsoft.Research.DynamicDataDisplay.Markers.MarkerGenerators.Rendering;

	public class RenderingChart : MarkerChart
	{
		private List<object> data = new List<object>();
		private RenderingChartCanvas renderingCanvas = new RenderingChartCanvas();

		public RenderingChart()
		{
			//renderingCanvas.SetBinding(ViewportPanel.ViewportBoundsProperty, new Binding { Path = new PropertyPath("(0)", Viewport2D.ContentBoundsProperty), Source = this });
			ViewportPanel.SetViewportBounds(renderingCanvas, new DataRect(0, 0, 1, 1));
			CurrentItemsPanel.Children.Add(renderingCanvas);
		}

		protected override void OnMarkerGeneratorReplaced(MarkerGenerator prevGenerator, MarkerGenerator currGenerator)
		{
			base.OnMarkerGeneratorReplaced(prevGenerator, currGenerator);

			if (renderingCanvas.Parent == null)
				CurrentItemsPanel.Children.Add(renderingCanvas);
		}

		protected override void OnMarkerBuilderChanged(object sender, EventArgs e)
		{
			base.OnMarkerBuilderChanged(sender, e);

			if (renderingCanvas.Parent == null)
				CurrentItemsPanel.Children.Add(renderingCanvas);
			renderingCanvas.Data = data;
			renderingCanvas.Renderer = (MarkerRenderer)MarkerBuilder.CreateMarker(null);
		}

		protected override void DrawAllMarkers(bool reuseExisting, bool continueAfterDataPrepaired)
		{
			base.DrawAllMarkers(reuseExisting, continueAfterDataPrepaired);
			if (renderingCanvas.Parent == null)
				CurrentItemsPanel.Children.Add(renderingCanvas);
			renderingCanvas.InvalidateVisual();
		}

		protected override void OnItemsPanelChanged()
		{
			base.OnItemsPanelChanged();

			CurrentItemsPanel.Children.Add(renderingCanvas);
		}

		protected override void CreateAndAddMarker(object dataItem, int actualChildIndex)
		{
			if (dataItem is IndexWrapper<Point>)
			{
				dataItem = ((IndexWrapper<Point>)dataItem).Data;
			}
			data.Add(dataItem);
		}
	}
}
