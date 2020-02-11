namespace ConwayLife.Core
{
    public class ResolveStrategyConfigurer<TBuilder, TCell> : CommonMapBuilder<TCell>
        where TBuilder : ResolveStrategyConfigurer<TBuilder,TCell>
        where TCell : new()
    {
        public TBuilder SetElementResolveStrategy(IElementsResolveStrategy<TCell> elementsResolveStrategy)
        {
            map.elementsResolveStrategy = elementsResolveStrategy;

            return (TBuilder) this;
        }
    }
}