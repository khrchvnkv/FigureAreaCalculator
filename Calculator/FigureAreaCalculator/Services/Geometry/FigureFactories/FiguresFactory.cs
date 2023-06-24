using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public class FiguresFactory
    {
        private readonly IFigureFactoryChain _factoryChain;
        
        public FiguresFactory()
        {
            var circleFigureFactory = new CircleFiguresFactory();
            var triangleFigureFactory = new TriangleFiguresFactory();

            // Setup factory chain
            circleFigureFactory.SetNextFactoryChain(triangleFigureFactory);
            _factoryChain = circleFigureFactory;
        }
        public IFigure CreateFigure(in float[] figureParams)
        {
            if (IsFigureParamsCorrect(figureParams))
            {
                return _factoryChain.GetAnyFigure(figureParams);
            }

            throw new FigureParamsFormatException();
        }
        public IFigure CreateFigure(in GeometryType geometryType, in float[] figureParams)
        {
            if (IsFigureParamsCorrect(figureParams))
            {
                return _factoryChain.GetConcreteFigure(geometryType, figureParams);
            }

            throw new FigureParamsFormatException();
        }
        private bool IsFigureParamsCorrect(in float[] figureParams)
        {
            foreach (var param in figureParams)
            {
                if (param < 0.0f) return false;
            }
            return true;
        }
    }
}