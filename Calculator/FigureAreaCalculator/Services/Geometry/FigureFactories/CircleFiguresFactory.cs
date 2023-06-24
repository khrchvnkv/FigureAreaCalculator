using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public class CircleFiguresFactory : FigureFactory
    {
        protected override GeometryType CreatedFiguresType => GeometryType.Circle;

        public override IFigure GetAnyFigure(in float[] figureParams)
        {
            if (TryGetCircle(figureParams, out var circle)) return circle;
            return base.GetAnyFigure(figureParams);
        }
        protected override IFigure GetConcreteFigure(in float[] figureParams)
        {
            if (TryGetCircle(figureParams, out var circle)) return circle;
            throw new FigureParamsFormatException();
        }
        private bool TryGetCircle(in float[] figureParams, out IFigure circle)
        {
            circle = null;
            if (figureParams.Length == 1)
            {
                circle = GetCircle(figureParams[0]);
                return true;
            }
            return false;
        }
        private IFigure GetCircle(in float radius) => new Circle(radius);
    }
}