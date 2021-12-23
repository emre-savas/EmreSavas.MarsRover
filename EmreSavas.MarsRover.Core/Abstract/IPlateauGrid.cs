using System;
using System.Collections.Generic;
using System.Text;

namespace EmreSavas.MarsRover.Core.Abstract
{
    public interface IPlateauGrid
    {
        int GridX { get; set; }
        int GridY { get; set; }
        bool CheckInit { get; }
        bool DrawPlateauGrid(string gridSizeInput);
        IList<IRover> Rovers { get; set; }
    }
}
