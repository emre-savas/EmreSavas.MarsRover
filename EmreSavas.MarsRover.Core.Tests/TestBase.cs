using EmreSavas.MarsRover.Core.Concrete;
using Moq;

namespace EmreSavas.MarsRover.Core.Tests
{
    public class TestBase
    {
        public Mock<PlateauGrid> _mockPlateauGrid;
        public PlateauGrid PlateauGrid;
        
        public TestBase()
        {
            PlateauGrid = new PlateauGrid(5, 5);
               _mockPlateauGrid = new Mock<PlateauGrid>();
        }

        public string AnGridSize()
        {
            return "5 5";
        }
    }
}