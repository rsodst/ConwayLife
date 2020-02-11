using System;
using System.Collections.Generic;
using System.Drawing;

namespace Client.RenderBackend
{
    public class GdiRenderer
    {
        public List<Action<Graphics>> pipeline = new List<Action<Graphics>>();
        BufferedGraphics bufferedGraphics;
        Graphics graphics;

        public GdiRenderer(Size size, IntPtr hwnd)
        {
            graphics = Graphics.FromHwnd(hwnd);
            bufferedGraphics = BufferedGraphicsManager.Current.Allocate(graphics, new Rectangle(Point.Empty, size));
        }

        public void Render()
        {
            bufferedGraphics.Graphics.Clear(Color.Black);
            
            pipeline.ForEach(renderMethod => renderMethod.Invoke(bufferedGraphics.Graphics));
            
            bufferedGraphics.Render();
        }

        public void Dispose()
        {
            graphics?.Dispose();
            graphics = default;
            bufferedGraphics?.Dispose();
            bufferedGraphics = default;
        }
    }
}