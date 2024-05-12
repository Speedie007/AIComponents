

using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace  AiComponents.Graph.Interfaces
{
    public partial interface IGraphWeightedEdge<TVertex, TWeightType> : IGraphEdge<TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TWeightType : unmanaged
    {
        TWeightType Metric { get; }
    }
}
