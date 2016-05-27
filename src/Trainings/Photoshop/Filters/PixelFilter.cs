using System;

namespace MyPhotoshop
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters> where TParameters: IParameters, new()
    {
        private readonly string _name;

        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processPixel)
        {
            _name = name;
            ProcessPixel = processPixel;
        }

        public override Photo Process(Photo original, TParameters parameters)
        {
            var result = new Photo(original.Width, original.Height);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], parameters);
                }
            }

            return result;
        }

        public Func<Pixel, TParameters, Pixel> ProcessPixel { get; }

        public override string ToString()
        {
            return _name;
        }
    }
}