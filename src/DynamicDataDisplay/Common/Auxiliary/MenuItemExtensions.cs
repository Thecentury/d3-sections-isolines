namespace Microsoft.Research.DynamicDataDisplay.Common.Auxiliary
{
	using System.Linq;
	using System.Windows.Controls;

	internal static class MenuItemExtensions
	{
		public static MenuItem FindChildByHeader(this MenuItem parent, string header)
		{
			return parent.Items.OfType<MenuItem>().Where(subMenu => subMenu.Header == header).FirstOrDefault();
		}
	}
}
