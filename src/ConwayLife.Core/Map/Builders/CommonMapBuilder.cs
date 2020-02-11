namespace ConwayLife.Core
{
    public abstract class CommonMapBuilder<TCell>
        where TCell : new()
    {
        protected Map<TCell> map;

        public CommonMapBuilder()
        {
            map = new Map<TCell>();
        }

        public Map<TCell> Build()
        {
            return map;
        }
    }

   
}