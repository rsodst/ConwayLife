namespace ConwayLife.Core
{
    public class SafeResolveStrategy<TCell> : IElementsResolveStrategy<TCell> 
        where TCell : new()
    {
        public TCell Get(TCell[][] field, long x, long y)
        {
            if (x >= 0 && x < field[0].Length && y >= 0 && y < field.Length) return field[y][x];

            return default;
        }

        public TCell Set(TCell[][] field, long x, long y, TCell value)
        {
            if (x >= 0 && x < field[0].Length && y >= 0 && y < field.Length) field[y][x] = value;

            return value;
        }
    }
}