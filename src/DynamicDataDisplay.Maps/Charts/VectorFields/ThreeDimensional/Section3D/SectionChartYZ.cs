namespace Microsoft.Research.DynamicDataDisplay.Maps.Charts.VectorFields
{
	using System.Windows.Media.Media3D;

	public sealed class SectionChartYZ : Section3DChartBase
	{
		public SectionChartYZ()
		{
			UpdateUI();
		}

		public override void UpdateUI()
		{
			billboard.LowerLeft = new Point3D(ThirdCoordinate, Center.X - Width / 2, Center.Y - Height / 2);
			billboard.LowerRight = new Point3D(ThirdCoordinate,  Center.X + Width / 2, Center.Y - Height / 2);
			billboard.UpperLeft = new Point3D(ThirdCoordinate, Center.X - Width / 2, Center.Y + Height / 2);
			billboard.UpperRight = new Point3D(ThirdCoordinate, Center.X + Width / 2, Center.Y + Height / 2);

			base.UpdateUI();
		}	
	}
}
