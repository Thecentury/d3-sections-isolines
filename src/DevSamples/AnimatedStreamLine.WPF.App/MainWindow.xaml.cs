namespace AnimatedStreamLine.WPF.App
{
	using System;
	using System.Diagnostics;
	using System.Windows;
	using System.Windows.Threading;
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

		private readonly PotentialField field = new PotentialField();
		private readonly DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
		private readonly Stopwatch stopwatch = Stopwatch.StartNew();
		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			timer.Tick += timer_Tick;
			timer.Start();

			DataContext = VectorField2D.CreateDynamicTangentPotentialField(field);
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			double time = stopwatch.Elapsed.TotalSeconds / 10;
			field.Clear();

			field.AddPotentialPoint(100 + 50 * Math.Cos(time) + 10 * Math.Cos(2.1 * time), 100 + 40 * Math.Sin(time), 1);
			field.AddPotentialPoint(20, 10, -1);
			field.AddPotentialPoint(180, 20, 3);
			field.AddPotentialPoint(20, 180, -0.5);
			field.AddPotentialPoint(180, 180, 2);

			field.RaiseChanged();
		}
	}
}
