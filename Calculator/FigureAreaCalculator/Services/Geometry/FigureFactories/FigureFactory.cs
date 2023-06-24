using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public abstract class FigureFactory : IFigureFactoryChain
    {
        protected abstract GeometryType CreatedFiguresType { get; }
        
        private FigureFactory? _nextFactoryChain;

        public void SetNextFactoryChain(in FigureFactory nextFactoryChain)
        {
            if (nextFactoryChain == this) throw new ArgumentException("The chain should not create a closed loop");
            _nextFactoryChain = nextFactoryChain;
        }
        public virtual IFigure GetAnyFigure(in float[] figureParams)
        {
            if (_nextFactoryChain != null) return _nextFactoryChain.GetAnyFigure(figureParams);

            throw new FigureParamsFormatException();
        }
        public IFigure GetConcreteFigure(in GeometryType geometryType, in float[] figureParams)
        {
            if (geometryType == CreatedFiguresType) return GetConcreteFigure(figureParams);

            if (_nextFactoryChain != null) return _nextFactoryChain.GetConcreteFigure(geometryType, figureParams);
            throw new FigureParamsFormatException();
        }
        protected abstract IFigure GetConcreteFigure(in float[] figureParams);
    }
}