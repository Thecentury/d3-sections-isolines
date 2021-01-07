//------------------------------------------
// ArrowEnds.cs (c) 2007 by Charles Petzold
//------------------------------------------

namespace Petzold.Media2D
{
    using System;

    /// <summary>
    ///     Indicates which end of the line has an arrow.
    /// </summary>
    [Flags]
    public enum ArrowEnds
    {
        None = 0,
        Start = 1,
        Begin = 1,
        End = 2,
        Both = 3
    }
}