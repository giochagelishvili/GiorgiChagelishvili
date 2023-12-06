namespace Practice_3
{
    internal class Triangle
    {
        int _FirstSide;
        int _SecondSide;
        int _ThirdSide;

        public int FirstSide
        {
            get
            {
                return _FirstSide;
            }
            set
            {
                if (value > 0)
                    _FirstSide = value;
            }
        }

        public int SecondSide
        {
            get
            {
                return _SecondSide;
            }
            set
            {
                if (value > 0)
                    _SecondSide = value;
            }
        }

        public int ThirdSide
        {
            get
            {
                return _ThirdSide;
            }
            set
            {
                bool firstAndSecond = _FirstSide + _SecondSide > value;
                bool firstAndThird = _FirstSide + value > _SecondSide;
                bool secondAndThird = _SecondSide + value > _FirstSide;

                if (firstAndSecond && firstAndThird && secondAndThird)
                {
                    _ThirdSide = value;
                    Console.WriteLine($"Perimeter of the triangle is: {GetPerimeter()}");
                    Console.WriteLine($"Area of the triangle is: {GetArea()}");
                }
                else
                    Console.WriteLine("It is not valid triangle.");
            }
        }

        public int GetPerimeter()
        {
            return _FirstSide + _SecondSide + _ThirdSide;
        }

        public int GetArea()
        {
            int semiperimeter = (_FirstSide + _SecondSide + _ThirdSide) / 2;

            double area = Math.Sqrt(semiperimeter * (semiperimeter - _FirstSide) * (semiperimeter - _SecondSide) * (semiperimeter - _ThirdSide));

            return (int)area;
        }
    }
}
