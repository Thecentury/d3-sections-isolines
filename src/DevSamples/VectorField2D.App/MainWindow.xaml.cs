using vf = Microsoft.Research.DynamicDataDisplay.SampleDataSources;

namespace VectorField2D.App
{
	using System.Windows;

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

		void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			vf.PotentialField field = new vf.PotentialField();
			field.AddPotentialPoint(100,100,1);
			DataContext = vf.VectorField2D.CreateTangentPotentialField(field);
		}
	}
}
