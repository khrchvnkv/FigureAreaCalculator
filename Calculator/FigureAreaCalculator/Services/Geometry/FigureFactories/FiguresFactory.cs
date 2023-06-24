using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public class FiguresFactory
    {
        private readonly FigureFactory _circleFigureFactory;
        private readonly FigureFactory _triangleFigureFactory;

        private readonly IFigureFactoryChain _factoryChain;
        
        public FiguresFactory()
        {
            _circleFigureFactory = new CircleFiguresFactory();
            _triangleFigureFactory = new TriangleFiguresFactory();

            // Setup factory chain
            _circleFigureFactory.SetNextFactoryChain(_triangleFigureFactory);
            _factoryChain = _circleFigureFactory;
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
                switch (geometryType)
                {
                    case GeometryType.Circle:
                        return _circleFigureFactory.GetConcreteFigure(figureParams);
                    case GeometryType.Triangle:
                        return _triangleFigureFactory.GetConcreteFigure(figureParams);
                }
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