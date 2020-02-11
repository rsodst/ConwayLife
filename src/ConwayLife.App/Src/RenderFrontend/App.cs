using System.Drawing;
using System.Windows.Forms;
using Client.RenderBackend;
using ConwayLife.Core;

namespace Client
{
    public class App : Main
    {
        private IGenerator<bool> generator;
        private GdiRenderer renderer;
        private MapRenderer mapRender;
        private Map<bool> map;
        private CursorRenderer cursorRenderer;
        private GridRenderer gridRenderer;
        private bool IsPlay;
        private int baseCellSize = 10;

        public bool IsRunning = true;

        public App() : base()
        {
            // configure map

            var mapSize = new Size(120, 120);

            renderer = new GdiRenderer(Size, Handle);

            map = MapBuilder<bool>.Map.CreateEmptyMap(mapSize)
                .SetCellLifeChecker(new BoolCellLifeStatusOperator())
                .SetElementResolveStrategy(new SafeResolveStrategy<bool>())
                .Build();

            generator = new BoolGenerator(map);

            // configure renderer details

            var cellSize = baseCellSize;

            cursorRenderer = new CursorRenderer(cellSize);
            mapRender = new MapRenderer(map, cellSize);
            gridRenderer = new GridRenderer(mapSize, cellSize);

            // configure events

            KeyPreview = true;

            Closing += (x, y) => IsRunning = false;

            MouseMove += (x, y) =>
            {
                var position = RountToNearest(new Point(y.X, y.Y), cellSize);

                cursorRenderer.position = position;
            };

            MouseClick += (x, y) =>
            {
                Stop();

                var position = RountToNearest(new Point(y.X, y.Y), cellSize);

                position.X -= mapRender.XShift;
                position.Y -= mapRender.YShift;

                map.SetCellStatus(position.X / cellSize, position.Y / cellSize, !map[position.X / cellSize, position.Y / cellSize]);
            };

            MouseWheel += (x, y) =>
            {
                if (y.Delta < 0 && cellSize > 4)
                {
                    cellSize-=1;
                    mapRender.cellSize = cellSize;
                    gridRenderer.cellSize = cellSize;
                    cursorRenderer.cellSize = cellSize;
                }
                else if (y.Delta > 0 && cellSize < 14)
                {
                    cellSize+=1;
                    mapRender.cellSize = cellSize;
                    gridRenderer.cellSize = cellSize;
                    cursorRenderer.cellSize = cellSize;
                }
            };


            StartButton.Click += (x, y) => Play();

            StopButton.Click += (x, y) => Stop();

            ResetButton.Click += (x, y) =>
            {
                Stop();

                cellSize = baseCellSize;

                ResetMapRender(cellSize);

                ResetGridRender(cellSize);

                cursorRenderer.cellSize = cellSize;

                generator.Reset();
            };

            KeyDown += (x, y) =>
            {
                if (y.KeyCode == Keys.W)
                {
                    gridRenderer.YShift -= cellSize;
                    mapRender.YShift -= cellSize;
                }

                if (y.KeyCode == Keys.S)
                {
                    gridRenderer.YShift += cellSize;
                    mapRender.YShift += cellSize;
                }

                if (y.KeyCode == Keys.A)
                {
                    gridRenderer.XShift -= cellSize;
                    mapRender.XShift -= cellSize;
                }

                if (y.KeyCode == Keys.D)
                {
                    gridRenderer.XShift += cellSize;
                    mapRender.XShift += cellSize;
                }

                if (y.KeyCode == Keys.Z)
                {
                    Stop();
                    generator.PrevGeneration();
                }

                if (y.KeyCode == Keys.X)
                {
                    Stop();
                    generator.NextGeneration();
                }
            };

            // configure render pipeline

            renderer.pipeline.Add(graphics => gridRenderer.DrawGrid(graphics));

            renderer.pipeline.Add(graphics => mapRender.DrawMap(graphics));

            renderer.pipeline.Add(graphics => cursorRenderer.DrawCursor(graphics));
        }


        public new void Update()
        {
            if (IsRunning == false) return;

            renderer.Render();

            if (IsPlay) generator.NextGeneration();

            if (generator.IsNothingChanges()) Stop();
        }

        // private 

        private Point RountToNearest(Point point, int cellSize)
        {
            var x = (point.X - cellSize / 2 + cellSize / 2) / cellSize * cellSize;
            var y = (point.Y - cellSize / 2 + cellSize / 2) / cellSize * cellSize;

            return new Point(x, y);
        }

        private void Stop()
        {
            Text = "Stopped";
            IsPlay = false;
        }

        private void Play()
        {
            Text = "Played";
            IsPlay = true;
        }

        private void ResetMapRender(int cellSize)
        {
            mapRender.cellSize = cellSize;
            mapRender.XShift = 0;
            mapRender.YShift = 0;
        }

        private void ResetGridRender(int cellSize)
        {
            gridRenderer.cellSize = cellSize;
            gridRenderer.XShift = 0;
            gridRenderer.YShift = 0;
        }
    }
}