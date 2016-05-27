using System;
using System.Windows.Forms;

namespace MyPhotoshop
{
    public class MainClass
	{
        [STAThread]
		public static void Main(string[] args)
		{
			var window = new MainWindow();

            window.AddFilter(new PixelFilter<LighteningParameters>(
                "Осветление/затемнение", 
                (original, parameters) => original * parameters.Coefficient
            ));

            window.AddFilter(new PixelFilter<EmptyParameters>(
                "Оттенки серого",
                (original, parameters) =>
                {
                    double lightness = 0.3d*original.R + 0.59d*original.G + 0.11*original.B;
                    return new Pixel(lightness, lightness, lightness);
                }
            ));

            window.AddFilter(new TransformFilter<EmptyParameters>("Отразить по горизонтали", new FlipTransformer()));

            window.AddFilter(new TransformFilter<RotationParameters>("Свободное вращение", new FreeRotationTransformer()));

			Application.Run(window);
		}
	}
}