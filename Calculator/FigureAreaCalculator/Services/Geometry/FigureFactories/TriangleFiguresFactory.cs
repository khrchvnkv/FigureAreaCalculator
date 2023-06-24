using FigureAreaCalculator.Services.Geometry.Exceptions;
using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.Services.Geometry.FigureFactories
{
    public class TriangleFiguresFactory : FigureFactory
    {
        protected override GeometryType CreatedFiguresType => GeometryType.Triangle;

        public override IFigure GetAnyFigure(in float[] figureParams)
        {
            if (TryGetTriangleWithThreeSides(figureParams, out var triangleWithThreeSides))
            {
                return triangleWithThreeSides;
            }
            return base.GetAnyFigure(figureParams);
        }
        protected override IFigure GetConcreteFigure(in float[] figureParams)
        {
            if (TryGetTriangleWithThreeSides(figureParams, out var triangle)) return triangle;
            throw new FigureParamsFormatException();
        }
        private bool TryGetTriangleWithThreeSides(in float[] figureParams, out TriangleWithThreeSides triangle)
        {
            triangle = null;
            if (figureParams.Length == 3)
            {
                triangle = GetTriangleWithThreeSides(figureParams[0], figureParams[1], figureParams[2]);
                if (triangle.IsCorrectTriangle()) return true;
            }
            return false;
        }
        private TriangleWithThreeSides GetTriangleWithThreeSides(in float side1, in float side2, in float side3) =>
            new(side1, side2, side3);
    }
}