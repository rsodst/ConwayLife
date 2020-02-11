namespace ConwayLife.Core
{
    public interface IElementsResolveStrategy<TCell>
        where TCell : new()
    {
        public TCell Get(TCell[][] field, long x, long y);
        public TCell Set(TCell[][] field, long x, long y, TCell value);
    }
}