namespace FigureAreaCalculator.Services.Geometry.Figures
{
    public enum GeometryType
    {
        Circle,
        Triangle
    }
    public interface IFigure
    {
        GeometryType FigureType { get; }
        float GetAreaValue();
    }
}