using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public abstract class FigureFactory : IFigureFactoryChain
    {
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
        public abstract IFigure GetConcreteFigure(in float[] figureParams);
    }
}