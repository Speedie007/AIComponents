using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.BaseComponents
{
    public abstract class BaseGraphWeightedEdge<TVertex,TWeightDataType> :
        BaseGraphEdge<TVertex>, 
        IGraphWeightedEdge<TVertex,TWeightDataType>
       // where TNodeConext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeConext>
        where TWeightDataType : unmanaged
    {
        protected BaseGraphWeightedEdge():base() 
        {
        }

        //protected BaseGraphWeightedEdge() : base() {
        //    Metric = default;
        //}

        protected BaseGraphWeightedEdge(TVertex vertexNode, TVertex adjacentNode, TWeightDataType edgeMetric) : base(vertexNode, adjacentNode)
        {
            Metric = edgeMetric;
        }

        public TWeightDataType Metric { get; private set; }

    }
}
