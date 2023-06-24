using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.FigureFactories;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry
{
    public class GeometryService : IGeometryService
    {
        private readonly FiguresFactory _figuresFactory;

        public GeometryService() => _figuresFactory = new FiguresFactory();
        public IFigure CreateFigure(in float[] figureParams) => _figuresFactory.CreateFigure(figureParams);
        public IFigure CreateFigure(in GeometryType geometryType, in float[] figureParams) => _figuresFactory.CreateFigure(geometryType, figureParams);
    }
}