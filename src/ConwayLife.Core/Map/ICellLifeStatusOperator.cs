namespace ConwayLife.Core
{
    public interface ICellLifeStatusOperator<TCell>
        where TCell : new()
    {
        bool IsLife(TCell cell);

        TCell IvertCellStatus(TCell cell);
    }
}