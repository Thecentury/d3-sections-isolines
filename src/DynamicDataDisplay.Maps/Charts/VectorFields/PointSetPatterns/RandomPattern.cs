﻿namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields.Convolution
{
	using System;
	using System.Collections.Generic;
	using System.Windows;

	public sealed class RandomPattern : PointSetPattern
	{
		private static readonly Random rnd = new Random();
		public override IEnumerable<Point> GeneratePoints()
		{
			for (int i = 0; i < PointsCount; i++)
			{
				yield return new Point(rnd.NextDouble(), rnd.NextDouble());
			}
		}
	}
}
