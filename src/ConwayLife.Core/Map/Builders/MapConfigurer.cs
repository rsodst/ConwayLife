using System.Drawing;

namespace ConwayLife.Core
{
    public class MapConfigurer<TBuilder, TCell> : 
        ResolveStrategyConfigurer<MapConfigurer<TBuilder,TCell>, TCell>
        where TBuilder : MapConfigurer<TBuilder, TCell>
        where TCell : new()        
    {
        public TBuilder CreateEmptyMap(int width, int height)
        {
            map.field = new TCell[height][];

            for (var i = 0; i < height; ++i)
            {
                map.field[i] = new TCell[width];
            }
            
            return (TBuilder) this;
        }

        public TBuilder CreateEmptyMap(Size size)
        {
            map.field = new TCell[size.Height][];

            for (var i = 0; i < size.Height; ++i)
            {
                map.field[i] = new TCell[size.Width];
            }

            return (TBuilder)this;
        }
    }
}