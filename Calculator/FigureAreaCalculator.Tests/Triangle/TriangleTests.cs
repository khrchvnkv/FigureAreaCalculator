using FigureAreaCalculator.Services.Geometry.Figures;

namespace GeometryTests.Triangle
{
    public class TriangleTests
    {
        [Test]
        public void WhenCreateEquilateralTriangle_ThenReturnCorrectTriangleTrue()
        {
            var figure = new TriangleWithThreeSides(1, 1, 1);
            Assert.True(figure.IsCorrectTriangle());
        }
        [Test]
        public void WhenCreateTriangleWithSideGreaterThanSumOfTheOthers_ThenReturnCorrectTriangleFalse()
        {
            var figure = new TriangleWithThreeSides(1, 1, 5);
            Assert.False(figure.IsCorrectTriangle());
        }
        [Test]
        public void WhenCreateEquilateralTriangle_ThenReturnRectangularFalse()
        {
            var figure = new TriangleWithThreeSides(1, 1, 1);
            Assert.False(figure.IsRectangularTriangle());
        }
        [Test]
        public void WhenCreateRectangularTriangle_ThenReturnRectangularTrue()
        {
            var figure = new TriangleWithThreeSides(3, 4, 5);
            Assert.True(figure.IsRectangularTriangle());
        }
        [Test]
        public void WhenCreateRectangularTriangle_ThenReturnCorrectAreaValue()
        {
            var figure = new TriangleWithThreeSides(3, 4, 5);
            Assert.That(figure.GetAreaValue(), Is.EqualTo(6));
        }
    }
}