﻿namespace DynamicDataDisplay.Markers
{
	/// <summary>
	/// Interaction logic for CandleStickGenerator.xaml
	/// </summary>
	public partial class CandleStickGenerator : TemplateMarkerGenerator
	{
		public CandleStickGenerator()
		{
			InitializeComponent();
		}

		private int openPath;
		public int OpenPath
		{
			get => openPath;
			set => openPath = value;
		}
	}
}
