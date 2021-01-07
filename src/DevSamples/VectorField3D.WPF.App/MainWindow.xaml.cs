namespace VectorField3D.WPF.App
{
	using System.Windows;
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
			var dataSource = VectorField2D.CreateTangentPotentialField(256, 256,
				new PotentialPoint(new Point(20, 10), 1),
				new PotentialPoint(new Point(128, 128), -2),
				new PotentialPoint(new Point(65, 85), 3),
				new PotentialPoint(new Point(150, 30), 10),
				new PotentialPoint(new Point(100, 100), -5));
		
			meshChart.DataSource = dataSource;
			meshChart.Plotter.DataContext = dataSource;
		}
	}
}
