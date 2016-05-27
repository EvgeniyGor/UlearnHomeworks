using System.Drawing;

namespace MyPhotoshop
{
    public interface ITransformer<in TParameters> where TParameters : IParameters, new()
    {
        Size SizeTransform(Size oldSize, TParameters parameters);
        Point? PointTransform(Point point, Size oldSize, TParameters parameters);
    }
}