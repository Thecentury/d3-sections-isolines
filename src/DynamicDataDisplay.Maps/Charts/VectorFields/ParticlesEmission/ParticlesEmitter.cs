namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public class ParticlesEmitter : ParticlesEmitterBase
	{
		protected override void OnTimerTick(object sender, EventArgs e)
		{
			if (DataSource == null)
				return;

			width = DataSource.Width;
			height = DataSource.Height;

			if (stopwatch.Elapsed.TotalSeconds - prevEmitTime.TotalSeconds > emitDelta.TotalSeconds)
			{
				prevEmitTime = stopwatch.Elapsed;
				if(particles.Count < maxParticlesCount){
					foreach (var point in Pattern.GeneratePoints())
					{
						var particle = CreateParticle();

						var viewportPoint = PointToViewport(point);

						ViewportPanel.SetX(particle, viewportPoint.X);
						ViewportPanel.SetY(particle, viewportPoint.Y);
						particles.Add(particle);
						panel.Children.Add(particle);
					}
				}
			}

			base.OnTimerTick(sender, e);
		}

		public override void OnPlotterAttached(Plotter plotter)
		{
			base.OnPlotterAttached(plotter);
			timer.Start();
		}

		public override void OnPlotterDetaching(Plotter plotter)
		{
			timer.Stop();
			base.OnPlotterDetaching(plotter);
		}
	}
}
