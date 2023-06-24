namespace FigureAreaCalculator.Services.Geometry.Figures
{
    public class TriangleWithThreeSides : Triangle
    {
        private const int RoundingToDigitsPlaces = 5;
        
        private readonly float _side1;
        private readonly float _side2;
        private readonly float _side3;

        public TriangleWithThreeSides(float side1, float side2, float side3)
        {
            var sortedCollection = new List<float>() { side1, side2, side3 };
            sortedCollection.Sort();
            _side1 = sortedCollection[0];
            _side2 = sortedCollection[1];
            _side3 = sortedCollection[2];
        }
        public override float GetAreaValue()
        {
            var perimeterHalf = (_side1 + _side2 + _side3) / 2.0f;
            var area = MathF.Sqrt(perimeterHalf * (perimeterHalf - _side1) * (perimeterHalf - _side2) *
                                  (perimeterHalf - _side3));
            return area;
        }
        public bool IsCorrectTriangle() => _side1 + _side2 >= _side3;
        public bool IsRectangularTriangle()
        {
            return MathF.Round(SideSqr(_side1) + SideSqr(_side2), RoundingToDigitsPlaces) == 
                   MathF.Round(SideSqr(_side3), RoundingToDigitsPlaces);
            
            float SideSqr(float side) => MathF.Pow(side, 2);
        }
    }
}