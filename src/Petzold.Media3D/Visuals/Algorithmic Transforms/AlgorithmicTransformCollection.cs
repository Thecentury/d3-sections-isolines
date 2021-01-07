//---------------------------------------------------------------
// AlgorithmicTransformCollection.cs (c) 2007 by Charles Petzold
//---------------------------------------------------------------

namespace Petzold.Media3D
{
    using System.Windows;

    /// <summary>
    /// 
    /// </summary>
    public class AlgorithmicTransformCollection :
                                        FreezableCollection<AlgorithmicTransform>
    {
        protected override Freezable CreateInstanceCore()
        {
            return new AlgorithmicTransformCollection();
        }
    }
}
