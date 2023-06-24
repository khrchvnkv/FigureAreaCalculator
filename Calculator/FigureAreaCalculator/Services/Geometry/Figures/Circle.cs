namespace FigureAreaCalculator.Services.Geometry.Figures
{
    public class Circle : IFigure
    {
        private readonly float _radius;

        public GeometryType FigureType => GeometryType.Circle;
        
        public Circle(float radius) => _radius = radius;
        public float GetAreaValue() => MathF.PI * MathF.Pow(_radius, 2);
    }
}