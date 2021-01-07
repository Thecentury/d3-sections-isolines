﻿namespace DynamicDataDisplay.Markers.ForestDisplay
{
	using System.Windows.Media;

	public sealed class TreeSpeciesInfo
	{
		public TreeSpeciesInfo()
		{
		}

		public TreeSpeciesInfo(Brush brush, string viewID)
		{
			Brush = brush;
			ViewID = viewID;
		}

		public Brush Brush { get; set; }
		public string ViewID { get; set; }
	}
}