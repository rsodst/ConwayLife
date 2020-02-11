using System;
using System.Collections.Generic;
using System.Linq;

namespace ConwayLife.Core
{
    public class BoolGenerator : IGenerator<bool>
    {
        public BoolGenerator(Map<bool> map)
        {
            this.map = map ?? throw new ArgumentNullException(nameof(map));
        }

        public Map<bool> map { get; set; }

        private bool[][] previousState { get; set; }

        private bool[][] newState { get; set; }
        
        private Stack<bool[][]> generations = new Stack<bool[][]>();

        public bool IsNothingChanges()
        {
            if (previousState == null || newState == null)
            {
                return true;
            }

            for (var i = 0; i < map.Width; ++i)
                for (var j = 0; j < map.Height; ++j)
                    if (previousState[j][i] != newState[j][i])
                    {
                        return false;
                    }


            return true;
        }

        public void NextGeneration()
        {
            var changes = new List<(int j, int i, bool result)>();

            for (var i = 0; i < map.Width; ++i)
            {
                for (var j = 0; j < map.Height; ++j)
                {
                    var lifeNeighbor = map.GetLifeNeighbor(j, i);

                    if (map[j, i])
                    {
                        if (new[] { 2, 3 }.Contains(lifeNeighbor) == false) changes.Add((j, i, false));
                    }
                    else
                    {
                        if (lifeNeighbor == 3) changes.Add((j, i, true));
                    }
                }
            }

            previousState = map.field.Select(s => s.ToArray()).ToArray();

            generations.Push(previousState);

            foreach (var change in changes) map.SetCellStatus(change.j, change.i, change.result);

            newState = map.field.Select(s => s.ToArray()).ToArray();
        }

        public void PrevGeneration()
        {
            if (generations.Count > 0)
            {
                map.field = generations.Pop();
            }
        }

        public void Reset()
        {
            generations = new Stack<bool[][]>();

            for (var i = 0; i < map.Width; ++i)
                for (var j = 0; j < map.Height; ++j)
                    map[j, i] = false;
        }
    }
}