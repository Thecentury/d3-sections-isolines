//--------------------------------------------------
// PolyLineSegment3D.cs (c) 2007 by Charles Petzold
//--------------------------------------------------

namespace Petzold.Media3D
{
    using System.Windows;
    using System.Windows.Media.Media3D;

    public class PolyLineSegment3D : PathSegment3D
    {
        // Points Property.
        // ---------------
        /// <summary>
        /// 
        /// </summary>
        public static readonly DependencyProperty PointsProperty = 
            DependencyProperty.Register("Points", 
            typeof(Point3DCollection),
            typeof(PolyLineSegment3D));
        /// <summary>
        /// 
        /// </summary>
        public Point3DCollection Points
        {
            set => SetValue(PointsProperty, value);
            get => (Point3DCollection) GetValue(PointsProperty);
        }

        /// <summary>
        ///     Initializes a new instance of PolyLineSegment3D.
        /// </summary>
        public PolyLineSegment3D()
        {
            Points = new Point3DCollection();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "L" + Points;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override Freezable CreateInstanceCore()
        {
            return new PolyLineSegment3D();
        }
    }
}
