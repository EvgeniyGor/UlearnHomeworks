using System.Drawing;
using MemoryHandling;
using NUnit.Framework;

namespace ChallengesTests.MemoryHandling
{
    public class BitmapEditorTests : TestBase
    {
        [Test]
        public void SimpleTest()
        {
            var bitmap = (Bitmap)Image.FromFile(@"E:\CodeProjects\C#\ulearnhomeworks\src\Challenges\ChallengesTests\MemoryHandling\test.jpg");

            using (var bitmapEditor = new BitmapEditor(bitmap))
            {
                for (int i = 0; i < bitmap.Height / 2; ++i)
                {
                    for (int j = 0; j < bitmap.Width / 2; ++j)
                    {
                        bitmapEditor.SetPixel(i, j, 255, 255, 255);
                    }
                }
            }
        }
    }
}