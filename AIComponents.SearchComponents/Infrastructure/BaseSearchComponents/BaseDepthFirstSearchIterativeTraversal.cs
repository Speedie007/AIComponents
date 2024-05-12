using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract partial class BaseDepthFirstSearchIterativeTraversal< TGraph, TVertex, TEdge, TResultSet> :
        BaseGraphSearch< TGraph, TVertex, TEdge, TResultSet>,
        IGraphDepthFirstSearch<TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>, new()
        where TGraph : BaseGraph<TVertex, TEdge>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {

        public BaseDepthFirstSearchIterativeTraversal(TGraph graph, TVertex startVertexNode = default, TVertex endVertexNode = default) : base(graph, startVertexNode, endVertexNode)
        {
            ForwardFrontierStack = new Stack<TVertex>();
            ReverseFrontierStack = new Stack<TVertex>();
        }

        public Stack<TVertex> ForwardFrontierStack { get; private set; }
        public Stack<TVertex> ReverseFrontierStack { get; private set; }

        public override void ResetSearch()
        {
            base.ResetSearch();
            ForwardFrontierStack.Clear();
            ReverseFrontierStack.Clear();
        }
    }
}
