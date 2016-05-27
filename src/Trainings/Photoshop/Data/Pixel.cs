using System;

namespace MyPhotoshop
{
    public struct Pixel
    {
        public Pixel(double r, double g, double b)
        {
            R = CheckValue(r);
            G = CheckValue(g);
            B = CheckValue(b);
        }

        public double R { get; }
        public double G { get; }
        public double B { get; }

        public static Pixel operator *(Pixel pixel, double number)
        {
            return new Pixel(Trim(pixel.R*number), Trim(pixel.G*number), Trim(pixel.B*number));
        }

        public static double Trim(double value)
        {
            return value > 1.0 ? 1.0 : value < 0.0 ? 0.0 : value;
        }

        private static double CheckValue(double value)
        {
            if (value > 1.0 || value < 0.0)
            {
                throw new ArgumentException($"Value { value } out of range");
            }

            return value;
        }
    }
}