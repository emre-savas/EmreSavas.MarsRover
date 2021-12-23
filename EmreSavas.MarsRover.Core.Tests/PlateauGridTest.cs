using NUnit.Framework;

namespace EmreSavas.MarsRover.Core.Tests
{
    [TestFixture]
    public class PlateauGridTest : TestBase
    {
        [Test]
        public void DrawPlateauGrid_incoming_value_null_should_return_false()
        {
            Assert.IsFalse(PlateauGrid.DrawPlateauGrid(string.Empty));
        }

        [Test]
        public void DrawPlateauGrid_incoming_value_length_two_should_not_return_false()
        {
            Assert.IsFalse(PlateauGrid.DrawPlateauGrid(string.Empty));
        }

        [Test]
        public void DrawPlateauGrid_incoming_value_length_two_should_return_true()
        {
            Assert.IsTrue(PlateauGrid.DrawPlateauGrid(AnGridSize()));
        }
    }
}
