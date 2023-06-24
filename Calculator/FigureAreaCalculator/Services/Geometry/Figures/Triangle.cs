namespace FigureAreaCalculator.Services.Geometry.Figures
{
    public abstract class Triangle : IFigure
    {
        public GeometryType FigureType => GeometryType.Triangle;
        public abstract float GetAreaValue();
    }
}