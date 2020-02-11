namespace ConwayLife.Core
{
    public class BoolCellLifeStatusOperator : ICellLifeStatusOperator<bool>
    {
        public bool IsLife(bool cell)
        {
            return cell;
        }

        public bool IvertCellStatus(bool cell) => !cell;
    }
}