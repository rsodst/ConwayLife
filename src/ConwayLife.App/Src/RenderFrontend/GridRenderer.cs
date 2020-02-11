using System.Drawing;

namespace Client
{
    public class GridRenderer
    {  
        public int cellSize;
        private Size size;

        public int XShift { get; set; }
        public int YShift { get; set; }

        public GridRenderer(Size size, int cellSize)
        {
            this.size = size;
            this.cellSize = cellSize;
        }

        public void DrawGrid(Graphics graphics)
        {
            for (var i = 0; i <= size.Height; ++i)
                graphics.DrawLine(new Pen(Color.Green), XShift, (i * cellSize) + YShift, size.Width * cellSize + XShift, (i * cellSize) + YShift);

            for (var i = 0; i <= size.Width; ++i)
                graphics.DrawLine(new Pen(Color.Green), (i * cellSize) + XShift, YShift, (i * cellSize) + XShift, size.Height * cellSize + YShift);
        }
    }
}