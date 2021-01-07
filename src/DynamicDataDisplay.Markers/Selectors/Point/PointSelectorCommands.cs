namespace Microsoft.Research.DynamicDataDisplay.Charts.Selectors
{
	using System.Windows.Input;

	public static class PointSelectorCommands
	{
		private static readonly RoutedUICommand removePoint = new RoutedUICommand("Remove point"/*UIResources.PointSelector_RemovePoint*/, "RemovePoint", typeof(PointSelectorCommands));
		public static RoutedUICommand RemovePoint => removePoint;

		private static readonly RoutedUICommand changeMode = new RoutedUICommand("Change mode", "ChangeMode", typeof(PointSelectorCommands));
		public static RoutedUICommand ChangeMode => changeMode;

		private static readonly RoutedUICommand addPoint = new RoutedUICommand("Add point"/*UIResources.PointSelector_AddPoint*/, "AddPoint", typeof(PointSelectorCommands));
		public static RoutedUICommand AddPoint => addPoint;
	}
}
