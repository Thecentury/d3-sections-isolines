//------------------------------------------------
// StrokeCharacter.cs (c) 2007 by Charles Petzold
//------------------------------------------------

//-------------------------------------------------------
// This class describes the elements of the 
// *FontResourceDictionary.xaml files.
//
// The class is internal to the Petzold.Medi3D assembly.
//-------------------------------------------------------

namespace Petzold.Media3D
{
    using System.Windows.Media;

    class StrokeCharacter
    {
        int width;
        Geometry geo;

        public StrokeCharacter(int width, string strGeometry)
        {
            Width = width;
            Geometry = Geometry.Parse(strGeometry);
        }

        // The Width of the font character.
        public int Width
        {
            set => width = value;
            get => width;
        }

        // The Geometry that defines the font character.
        public Geometry Geometry
        {
            set => geo = value;
            get => geo;
        }
    }
}