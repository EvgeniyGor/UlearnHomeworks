namespace MyPhotoshop
{
	public class Photo
	{
		private readonly Pixel[,] _data;

	    public Photo(int width, int height)
	    {
	        Width = width;
	        Height = height;
            _data = new Pixel[Height, Width];
	    }

        public int Width { get; }
        public int Height { get; }

	    public Pixel this[int x, int y]
	    {
	        get { return _data[y, x]; }
	        set { _data[y, x] = value; }
	    }
	}
}

