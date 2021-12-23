using EmreSavas.MarsRover.Core.Abstract;
using System.Collections.Generic;

namespace EmreSavas.MarsRover.Core.Concrete
{
    public class PlateauGrid : IPlateauGrid
    {
        public int GridX { get; set; }
        public int GridY { get; set; }
        public bool CheckInit { get; private set; }
        public IList<IRover> Rovers { get; set; }

        public PlateauGrid()
        {
            this.Rovers = new List<IRover>();
        }

        public PlateauGrid(int gridX, int gridY) : this()
        {
            GridX = gridX;
            GridY = gridY;
        }
        
        public bool DrawPlateauGrid(string gridSizeInput)
        {
            this.CheckInit = false;
            if (string.IsNullOrWhiteSpace(gridSizeInput)) return this.CheckInit;
            var gridSize = gridSizeInput.Split(' ');
            if (gridSize.Length != 2) return this.CheckInit;
            if (!int.TryParse(gridSize[0], out var gridX)) return this.CheckInit;
            if (!int.TryParse(gridSize[1], out var gridY)) return this.CheckInit;
            this.GridX = gridX;
            this.GridY = gridY;
            this.CheckInit = true;
            return this.CheckInit;
        }
    }
}
