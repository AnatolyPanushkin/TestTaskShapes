using System;

namespace ShapesSquare
{
    public abstract class Shape
    {
        public Type ThisType { get; set; }

        public Shape(Type type)
        {
            ThisType = type;
        }

        public abstract double Square();

        public virtual string ToString()
        {
            return $"Тип {ThisType.Name}";
        }
    }

    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c) : base(typeof(Triangle))
        {
            if (CheckTriangle.ExistOfTriangle(a,b,c))
            {
                CheckTriangle.CheckRightTriangle(a,b,c);
                A = a;
                B = b;
                C = c;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override double Square()
        {
           
            double p = (A + B + C) / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        } 
        
        
    }


    public class Circle : Shape
    {
        public double R { get; set; }

        public Circle(double r) : base(typeof(Circle))
        {
            R = r;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override double Square()
        {
            return Math.PI * R * R;
        }

    }

    public class UnknownShape : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double R { get; set; }

        public UnknownShape(double r) : base(typeof(Circle))
        {
            R = r;
        }

        public UnknownShape(double a, double b, double c) : base(typeof(Triangle))
        {
            if (CheckTriangle.ExistOfTriangle(a, b, c))
            {
                CheckTriangle.CheckRightTriangle(a,b,c);
                A = a;
                B = b;
                C = c;
            }
        }

        public override double Square()
        {
            if (!R.Equals(0))
            {
                return Math.PI * R * R;
            }
            else
            {
                double p = (A + B + C) / 2;
                return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

    public class CheckTriangle
    {
        public static bool ExistOfTriangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new TriangleException("Треугольник не существует - сторона\\ы меньше или равны 0");
            }
            if (a > (b + c) || b > (a + c) || c > (a + b))
            {
                throw new TriangleException("Треугольник не существует - сумма двух сторон треугольника не больше третей стороны");
            }
            
            return true; 
            
        }
        
        public static void CheckRightTriangle(double a, double b, double c)
        {
            if (b * b + c * c - a * a == 0 || b * b + a * a - c * c == 0 || a * a + c * c - b * b == 0)
            {
                Console.WriteLine("Треугольник прямоугольный");
            }
            else
            {
                Console.WriteLine("Треугольник не прямоугольный");
            }
        }
    }
    
    
    
}