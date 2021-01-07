namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows.Media.Media3D;

	public sealed class SectionChartXY : Section3DChartBase
	{
		public SectionChartXY()
		{
			UpdateUI();
		}

		public override void UpdateUI()
		{
			billboard.LowerLeft = new Point3D(Center.X - Width / 2, Center.Y - Height / 2, ThirdCoordinate);
			billboard.LowerRight = new Point3D(Center.X + Width / 2, Center.Y - Height / 2, ThirdCoordinate);
			billboard.UpperLeft = new Point3D(Center.X - Width / 2, Center.Y + Height / 2, ThirdCoordinate);
			billboard.UpperRight = new Point3D(Center.X + Width / 2, Center.Y + Height / 2, ThirdCoordinate);

			base.UpdateUI();
		}
	}
}
