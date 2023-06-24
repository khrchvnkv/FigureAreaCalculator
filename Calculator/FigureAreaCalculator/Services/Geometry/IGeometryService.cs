using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry
{
    public interface IGeometryService
    {
        IFigure CreateFigure(in float[] figureParams);
        IFigure CreateFigure(in GeometryType geometryType, in float[] figureParams);
    }
}