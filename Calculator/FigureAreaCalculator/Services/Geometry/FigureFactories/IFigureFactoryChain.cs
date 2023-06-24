using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public interface IFigureFactoryChain
    {
        void SetNextFactoryChain(in FigureFactory nextFactoryChain);
        IFigure GetAnyFigure(in float[] figureParams);
        IFigure GetConcreteFigure(in GeometryType geometryType, in float[] figureParams);
    }
}