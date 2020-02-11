using System;
using System.Drawing;
using ConwayLife.Core;

namespace Client
{
    public class MapRenderer
    {
        private Map<bool> map;
        public int cellSize;

        public int XShift { get; set; }
        public int YShift { get; set; }

        public MapRenderer(Map<bool> map, int cellSize)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
            this.cellSize = cellSize;
        }

        public void DrawMap(Graphics graphics)
        {
            for (var i = 0; i < map.Width; ++i)
                for (var j = 0; j < map.Height; ++j)
                    if (map[i, j])
                        graphics.FillRectangle(new SolidBrush(Color.Yellow), (i * cellSize) + XShift, (j * cellSize) + YShift, cellSize, cellSize);
        }
    }
}