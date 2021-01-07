namespace Microsoft.Research.DynamicDataDisplay.Common
{
	using System.Windows.Automation.Peers;

	public class PlotterAutomationPeer : FrameworkElementAutomationPeer
	{
		public PlotterAutomationPeer(Plotter owner)
			: base(owner)
		{

		}

		protected override AutomationControlType GetAutomationControlTypeCore()
		{
			return AutomationControlType.Custom;
		}

		protected override string GetClassNameCore()
		{
			return "Plotter";
		}
	}
}
