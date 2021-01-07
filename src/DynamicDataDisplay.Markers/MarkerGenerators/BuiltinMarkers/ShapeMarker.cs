﻿namespace DynamicDataDisplay.Markers
{
	using System;
	using System.Windows;
	using System.Windows.Data;
	using System.Windows.Media;
	using System.Windows.Shapes;

	public abstract class ShapeMarker : MarkerGenerator
	{
		protected ShapeMarker()
		{
			widthBinding = CreateBinding(MarkerWidthProperty);
			heightBinding = CreateBinding(MarkerHeightProperty);
			fillBinding = CreateBinding(MarkerFillProperty);
			strokeBinding = CreateBinding(MarkerStrokeProperty);
			strokeThicknessBinding = CreateBinding(MarkerStrokeThicknessProperty);
		}

		protected sealed override FrameworkElement CreateMarkerCore(object dataItem)
		{
			Shape shape = CreateShape();

			shape.Stretch = Stretch.Fill;

			shape.SetBinding(WidthProperty, widthBinding);
			shape.SetBinding(HeightProperty, heightBinding);
			shape.SetBinding(Shape.FillProperty, fillBinding);
			shape.SetBinding(Shape.StrokeProperty, strokeBinding);
			shape.SetBinding(Shape.StrokeThicknessProperty, strokeThicknessBinding);

            //foreach (var property in changedProperties)
            //{
            //    var value = GetValue(property);
            //    shape.SetValue(property, value);
            //}

			shape.DataContext = dataItem;

			return shape;
		}

		protected override void OnInitialized(EventArgs e)
		{
			RaiseEvent(new RoutedEventArgs(LoadedEvent, this));
			base.OnInitialized(e);
		}

        //private readonly List<DependencyProperty> changedProperties = new List<DependencyProperty>();
        //protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        //{
        //    base.OnPropertyChanged(e);

        //    // TODO: what for is this code?
        //    //var property = e.Property;
        //    //if (property != MarkerFillProperty &&
        //    //    property != MarkerHeightProperty &&
        //    //    property != MarkerWidthProperty &&
        //    //    property != MarkerStrokeProperty &&
        //    //    property != MarkerStrokeThicknessProperty)
        //    //{
        //    //    changedProperties.Add(property);
        //    //}
        //}

		protected abstract Shape CreateShape();

		#region Properties

		public double MarkerWidth
		{
			get => (double)GetValue(MarkerWidthProperty);
			set => SetValue(MarkerWidthProperty, value);
		}

		public static readonly DependencyProperty MarkerWidthProperty = DependencyProperty.Register(
		  "MarkerWidth",
		  typeof(double),
		  typeof(ShapeMarker),
		  new FrameworkPropertyMetadata(10.0));

		public double MarkerHeight
		{
			get => (double)GetValue(MarkerHeightProperty);
			set => SetValue(MarkerHeightProperty, value);
		}

		public static readonly DependencyProperty MarkerHeightProperty = DependencyProperty.Register(
		  "MarkerHeight",
		  typeof(double),
		  typeof(ShapeMarker),
		  new FrameworkPropertyMetadata(10.0));

		public Brush MarkerFill
		{
			get => (Brush)GetValue(MarkerFillProperty);
			set => SetValue(MarkerFillProperty, value);
		}

		public static readonly DependencyProperty MarkerFillProperty = DependencyProperty.Register(
		  "MarkerFill",
		  typeof(Brush),
		  typeof(ShapeMarker),
		  new FrameworkPropertyMetadata(Brushes.Blue));

		public Brush MarkerStroke
		{
			get => (Brush)GetValue(MarkerStrokeProperty);
			set => SetValue(MarkerStrokeProperty, value);
		}

		public static readonly DependencyProperty MarkerStrokeProperty = DependencyProperty.Register(
		  "MarkerStroke",
		  typeof(Brush),
		  typeof(ShapeMarker),
		  new FrameworkPropertyMetadata(Brushes.Black));

		public double MarkerStrokeThickness
		{
			get => (double)GetValue(MarkerStrokeThicknessProperty);
			set => SetValue(MarkerStrokeThicknessProperty, value);
		}

		public static readonly DependencyProperty MarkerStrokeThicknessProperty = DependencyProperty.Register(
		  "MarkerStrokeThickness",
		  typeof(double),
		  typeof(ShapeMarker),
		  new FrameworkPropertyMetadata(1.0));

		#endregion

		private Binding widthBinding;
		private Binding heightBinding;
		private Binding fillBinding;
		private Binding strokeBinding;
		private Binding strokeThicknessBinding;

		protected Binding CreateBinding(DependencyProperty sourceProperty)
		{
			Binding binging = new Binding { Path = new PropertyPath(sourceProperty.Name), Source = this };
			return binging;
		}
	}
}
