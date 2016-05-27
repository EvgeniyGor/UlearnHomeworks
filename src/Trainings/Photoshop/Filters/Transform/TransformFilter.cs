using System.Drawing;

namespace MyPhotoshop
{
    public class TransformFilter<TParameters> : ParametrizedFilter<TParameters> where TParameters: IParameters, new()
    {
        private readonly string _name;
        private readonly ITransformer<TParameters> _transformer;

        public TransformFilter(string name, ITransformer<TParameters> transformer)
        {
            _name = name;
            _transformer = transformer;
        }

        public override Photo Process(Photo photo, TParameters parameters)
        {
            var oldSize = new Size(photo.Width, photo.Height);
            var newSize = _transformer.SizeTransform(oldSize, parameters);
            var result = new Photo(newSize.Width, newSize.Height);

            for (int x = 0; x < newSize.Width; ++x)
            {
                for (int y = 0; y < newSize.Height; ++y)
                {
                    var point = new Point(x, y);
                    var oldPoint = _transformer.PointTransform(point, oldSize, parameters);

                    if (oldPoint.HasValue)
                    {
                        result[x, y] = photo[oldPoint.Value.X, oldPoint.Value.Y];
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            return _name;
        }
    }
}