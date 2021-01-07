namespace Lines2D.App
{
	using System;
	using System.Diagnostics;
	using System.Windows;
	using System.Windows.Media.Media3D;
	using System.Windows.Threading;

	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly DispatcherTimer timer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(50) };
		private readonly Stopwatch watch = Stopwatch.StartNew();
		private const int count = 50000;

		public MainWindow()
		{
			InitializeComponent();

			Loaded += MainWindow_Loaded;
		}

		private void MainWindow_Loaded(object sender, RoutedEventArgs e)
		{
			timer.Tick += timer_Tick;
			timer.Start();
		}

		void timer_Tick(object sender, EventArgs e)
		{
			double delta = watch.Elapsed.TotalSeconds;
			Point3DCollection collection = new Point3DCollection(count);
			for (int i = 0; i < count; i++)
			{
				double x = i / 12500.0;
				collection.Add(new Point3D(x, Math.Sin(x + delta), 0));
			}

			polyline.Points = collection;
		}
	}
}
