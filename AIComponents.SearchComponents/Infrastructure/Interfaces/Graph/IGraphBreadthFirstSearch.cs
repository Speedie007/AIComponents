using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;


namespace AIComponents.SearchComponents.Infrastructure.Interfaces.Graph
{
    public partial interface IGraphBreadthFirstSearch<TVertex>
            //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        Queue<TVertex> ForwardFrontierQueue { get; }
        Queue<TVertex> ReverseFrontierQueue { get; }
    }
}
