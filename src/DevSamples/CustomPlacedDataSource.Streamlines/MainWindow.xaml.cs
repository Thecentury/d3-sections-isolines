namespace CustomPlacedDataSource.Streamlines
{
	using System.Windows;
	using Microsoft.Research.DynamicDataDisplay.Common.Auxiliary;
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
			var dataSource = VectorField2D.CreateCircularField().ChangeGrid((ix, iy) => new Point(ix / 100.0 + 100, iy / 100.0 + 100));

			DataContext = dataSource;
		}
	}
}
