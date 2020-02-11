using System.Drawing;

namespace Client
{
    public class CursorRenderer
    {
        public int cellSize;
        public Point position;

        public CursorRenderer(int cellSize)
        {
            this.cellSize = cellSize;
        }

        public void DrawCursor(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Brown, position.X, position.Y, cellSize, cellSize);
        }
    }
}