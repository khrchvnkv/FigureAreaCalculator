using FigureAreaCalculator.Services.Geometry;
using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace GeometryTests;

public class GeometryServiceTests
{
    [Test]
    public void WhenIdentifyingFigureWith1Param_ThenReturnCircle()
    {
        var service = new GeometryService();
        var figure = service.CreateFigure(new[] { 1.0f });
        Assert.That(figure.GetType(), Is.EqualTo(typeof(Circle)));
    }
    [Test]
    public void WhenIdentifyingFigureWith3Param_ThenReturnTriangleWithThreeSides()
    {
        var service = new GeometryService();
        var figure = service.CreateFigure(new[] { 1.0f, 1.0f, 1.0f });
        Assert.That(figure.GetType(), Is.EqualTo(typeof(TriangleWithThreeSides)));
    }
    [Test]
    public void WhenIdentifyingFigureWithNegativeParam_ThenReturnFigureParamFormatException()
    {
        var service = new GeometryService();
        Assert.Throws<FigureParamsFormatException>(() => service.CreateFigure(new[] { -1.0f }));
    }
}