namespace Streamline3D
{
	using System.Windows;
	using System.Windows.Media.Media3D;
	using Microsoft.Research.DynamicDataDisplay.SampleDataSources;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			PotentialField3D field = new PotentialField3D();
			field.AddPotentialPoint(new Point3D(0.5, 0.5, 0.5), 2);
			field.AddPotentialPoint(new Point3D(0.2, 0.2, 0.5), -3);
			field.AddPotentialPoint(new Point3D(0.8, 0.2, 0.9), 10);
			field.AddPotentialPoint(new Point3D(0.3, 0.7, 0.1), 5);

			var dataSource3D = VectorField3D.CreateTangentPotentialField(field, 200, 200, 200);
			streamlineChart.DataSource = dataSource3D;
		}
	}
}
