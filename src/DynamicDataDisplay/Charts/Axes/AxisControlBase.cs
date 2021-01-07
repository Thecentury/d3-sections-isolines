namespace Microsoft.Research.DynamicDataDisplay.Charts
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;

    public abstract class AxisControlBase : ContentControl
    {
        #region Properties

        public HorizontalAlignment LabelsHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(LabelsHorizontalAlignmentProperty);
            set => SetValue(LabelsHorizontalAlignmentProperty, value);
        }

        public static readonly DependencyProperty LabelsHorizontalAlignmentProperty = DependencyProperty.Register(
          "LabelsHorizontalAlignment",
          typeof(HorizontalAlignment),
          typeof(AxisControlBase),
          new FrameworkPropertyMetadata(HorizontalAlignment.Center));


        public VerticalAlignment LabelsVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(LabelsVerticalAlignmentProperty);
            set => SetValue(LabelsVerticalAlignmentProperty, value);
        }

        public static readonly DependencyProperty LabelsVerticalAlignmentProperty = DependencyProperty.Register(
          "LabelsVerticalAlignment",
          typeof(VerticalAlignment),
          typeof(AxisControlBase),
          new FrameworkPropertyMetadata(VerticalAlignment.Center));

		public abstract Path TicksPath { get; }

        #endregion // end of Properties

    }
}
