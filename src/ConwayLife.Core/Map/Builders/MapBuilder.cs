namespace ConwayLife.Core
{
    public class MapBuilder<TCell> : CellCheckConfigurer<MapBuilder<TCell>, TCell>
        where TCell : new()
    {
        public static MapBuilder<bool> Map => new MapBuilder<bool>();
    }
}