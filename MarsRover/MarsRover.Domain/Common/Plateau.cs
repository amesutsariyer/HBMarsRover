namespace MarsRover.Domain.Common
{
    public class Plateau : Base,IPlataeuSize
    {
        public Plateau(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }


}
