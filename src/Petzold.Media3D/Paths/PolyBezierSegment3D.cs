//----------------------------------------------------
// PolyBezierSegment3D.cs (c) 2007 by Charles Petzold
//----------------------------------------------------

namespace Petzold.Media3D
{
    using System.Windows;
    using System.Windows.Media.Media3D;

    public class PolyBezierSegment3D : PathSegment3D
    {
        /// <summary>
        ///     Initializes a new instance of the <c>PolyBezierSegment3D</c> 
        ///     class.
        /// </summary>
        public PolyBezierSegment3D()
        {
            Points = new Point3DCollection();
        }

        // Points Property.
        // ---------------
        /// <summary>
        ///     Identifies the <c>Points</c> dependency property.
        /// </summary>
        public static readonly DependencyProperty PointsProperty = 
            DependencyProperty.Register("Points", 
            typeof(Point3DCollection),
            typeof(PolyBezierSegment3D),
            new PropertyMetadata(null));

        /// <summary>
        /// 
        /// </summary>
        public Point3DCollection Points
        {
            set => SetValue(PointsProperty, value);
            get => (Point3DCollection) GetValue(PointsProperty);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "C" + Points;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new PolyBezierSegment3D();
        }
    }
}
