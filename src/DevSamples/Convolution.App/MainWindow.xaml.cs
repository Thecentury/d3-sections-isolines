namespace Convolution.App
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
			DataContext = VectorField2D.CreateCircularField2(1000, 1000);
		}
	}
}
