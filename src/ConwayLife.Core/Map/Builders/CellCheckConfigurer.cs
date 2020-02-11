namespace ConwayLife.Core
{
    public class CellCheckConfigurer<TBuilder, TCell> :
        MapConfigurer<CellCheckConfigurer<TBuilder, TCell>, TCell>
        where TBuilder : CellCheckConfigurer<TBuilder, TCell>
        where TCell : new()
    {
        public TBuilder SetCellLifeChecker(ICellLifeStatusOperator<TCell> cellLifeChecker)
        {
            map.cellLifeChecker = cellLifeChecker;

            return (TBuilder) this;
        }
    }
}