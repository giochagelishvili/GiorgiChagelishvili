namespace Data_Structures_Practices.Classes
{
    public static class Point
    {
        // Calculates and returns the distance between two points on coordinate plane
        public static double CalculateDistance(Tuple<double, double> firstPoint, Tuple<double, double> secondPoint)
        {
            double firstX = firstPoint.Item1;
            double firstY = firstPoint.Item2;

            double secondX = secondPoint.Item1;
            double secondY = secondPoint.Item2;

            double subtractX = secondX - firstX;
            double subtractY = secondY - firstY;

            return Math.Sqrt(Math.Pow(subtractX, 2) +  Math.Pow(subtractY, 2));
        }
    }
}
