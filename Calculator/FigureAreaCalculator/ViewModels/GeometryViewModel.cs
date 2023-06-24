using FigureAreaCalculator.Services.Geometry.Figures;

namespace FigureAreaCalculator.ViewModels
{
    public class GeometryViewModel
    {
        public readonly GeometryType GeometryType;
        public readonly float Area;

        public GeometryViewModel(GeometryType geometryType, float area)
        {
            GeometryType = geometryType;
            Area = area;
        }
    }
}