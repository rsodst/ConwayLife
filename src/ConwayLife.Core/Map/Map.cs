using System.Linq;

namespace ConwayLife.Core
{
    public sealed class Map<TCell>
        where TCell : new()
    {
        public ICellLifeStatusOperator<TCell> cellLifeChecker;
        public IElementsResolveStrategy<TCell> elementsResolveStrategy;

        public TCell[][] field = null;

        public int Height => field.Length;
        public int Width => field[0].Length;

        public TCell this[int x, int y]
        {
            get => elementsResolveStrategy.Get(field, x, y);
            set => elementsResolveStrategy.Set(field, x, y, value);
        }

        public int GetLifeNeighbor(int x, int y)
        {
            var neighborhood = new[]
            {
                new[] {this[x - 1, y - 1], this[x, y - 1], this[x + 1, y - 1]},
                new[] {this[x - 1, y], this[x + 1, y]},
                new[] {this[x - 1, y + 1], this[x, y + 1], this[x + 1, y + 1]}
            };

            return neighborhood[0].Count(p => cellLifeChecker.IsLife(p)) +
                   neighborhood[1].Count(p => cellLifeChecker.IsLife(p)) +
                   neighborhood[2].Count(p => cellLifeChecker.IsLife(p));
        }

        public void SetCellStatus(int x, int y, bool isLife)
        {
            if ((cellLifeChecker.IsLife(this[x, y]) && isLife == false) ||
                (cellLifeChecker.IsLife(this[x, y]) == false && isLife))
            {
                this[x, y] = cellLifeChecker.IvertCellStatus(this[x, y]);
            }
        }
    }
}