namespace MarsRover.Domain.Common
{
    public class Plataeu : Base,IPlataeuSize
    {
        public Plataeu(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public int Width { get; set; }
        public int Height { get; set; }
    }


}
