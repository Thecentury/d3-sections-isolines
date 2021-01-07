namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Linq;
	using System.Windows;
	using System.Windows.Input;
	using Microsoft.Research.DynamicDataDisplay.Charts;

	public class DynamicParticlesEmitter : ParticlesEmitterBase
	{
		public override void OnPlotterAttached(Plotter plotter)
		{
			base.OnPlotterAttached(plotter);

			CommandBinding leftMouseDoubleClickBinding = null;
			foreach (var binding in plotter.CommandBindings.OfType<CommandBinding>())
			{
				if (binding.Command == ChartCommands.ZoomInToMouse)
					leftMouseDoubleClickBinding = binding;
			}
			if (leftMouseDoubleClickBinding != null)
				plotter.CommandBindings.Remove(leftMouseDoubleClickBinding);

			plotter.CentralGrid.MouseDown += CentralGrid_MouseDown;
		}

		public override void OnPlotterDetaching(Plotter plotter)
		{
			plotter.CentralGrid.MouseDown -= CentralGrid_MouseDown;

			base.OnPlotterDetaching(plotter);
		}

		private void CentralGrid_MouseDown(object sender, MouseButtonEventArgs e)
		{
			var newParticle = CreateParticle();
			Point position = e.GetPosition(Plotter.CentralGrid).ScreenToData(Plotter.Transform);
			ViewportPanel.SetX(newParticle, position.X);
			ViewportPanel.SetY(newParticle, position.Y);
			particles.Add(newParticle);
			panel.Children.Add(newParticle);
		}
	}
}
