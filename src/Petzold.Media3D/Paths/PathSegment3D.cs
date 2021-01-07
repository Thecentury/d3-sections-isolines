//----------------------------------------------
// PathSegment3D.cs (c) 2007 by Charles Petzold
//----------------------------------------------

namespace Petzold.Media3D
{
    using System.Windows;
    using System.Windows.Media.Animation;

    public abstract class PathSegment3D : Animatable
    {
        // IsStroked property.
        // -------------------
        public static readonly DependencyProperty IsStrokedProperty =
            DependencyProperty.Register("IsStroked", typeof(bool),
            typeof(PathSegment3D),
            new PropertyMetadata(true));

        public bool IsStroked
        {
            set => SetValue(IsStrokedProperty, value);
            get => (bool)GetValue(IsStrokedProperty);
        }

        // IsSmoothJoin property.
        // ----------------------
        public static readonly DependencyProperty IsSmoothJoinProperty =
            DependencyProperty.Register("IsSmoothJoin", typeof(bool),
            typeof(PathSegment3D),
            new PropertyMetadata(false));

        public bool IsSmoothJoin
        {
            set => SetValue(IsSmoothJoinProperty, value);
            get => (bool)GetValue(IsSmoothJoinProperty);
        }
    }
}
