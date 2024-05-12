/*
 * QuikGraph - Libaray For Reference purposes.
 * QuickGraph.NETStandard
 * */

using AiComponents.Graph.BaseComponents;
using AIComponents.Common.Interfaces;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Interfaces
{
    /// <summary>
    /// <para>NodeDataContext is the Model that you create to represent your Vertex.</para>
    /// <para>By default the model(NodeDataContext) must extend the NodeBase class, and only has a Id property from the base class.</para>
    /// <para>You can add your own custom properties if required in your base class implementation</para>
    /// </summary>
    /// <typeparam name="TVertex">
    /// <para>NodeDataContext is the Model that you create to represent your Vertex.</para></typeparam>
    /// <typeparam name="TEdge"></typeparam>
    public partial interface IGraph<TVertex, TEdge>
         //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge<TVertex>
       
    {
        #region Properties
        /// <summary>
        /// An adjacency list represents a graph as an array of linked lists.
        /// The KEY Of type TNODE => 
        /// </summary>
        SortedList<TVertex, LinkedList<TEdge>> GraphAdjacencyList { get; }
        bool IsDirectedGraph { get; }
        #endregion

        #region Methods
        bool ContainsEdge(TVertex vertexNode, TEdge adjacentNode);
        bool HasEdges(TVertex vertexNode);
        //BaseGraphEdge<TNodeContext,TVertex> forwardEdge, BaseGraphEdge<TNodeContext, TVertex> reverseEdge
        //bool TryAddEdge(BaseGraphEdge<TNodeContext, TVertex> forwardEdge, BaseGraphEdge<TNodeContext, TVertex> reverseEdge);
        bool TryAddEdge(TEdge forwardEdge, TEdge reverseEdge);
        bool TryRemoveVertex(TVertex vertexNode);
        TEdge? GetEdge(TVertex vertexNode, TVertex adjacentNode);
        LinkedList<TEdge> GetEdges(TVertex vertexNode);
        bool TryRemoveEdge(TVertex vertexNode, TEdge edge);
        bool TryAddVertex(TVertex vertexNode);
        bool HasVertex(TVertex vertexNode);
        TVertex GetVertex(int nodeId);
        List<TVertex> GetAllLeafNodes();
        double GetEdgeWeight(TEdge edge);
        bool SetEdgeWeight(TEdge edge, double edgeWeight = 0);
        bool IsTree();
        bool HasStartingNode();
        bool HasEndNode();
        int AmountOfEdges();
        IResult TryAddEdge(TEdge edge);
        //IResult TryAddEdge(TVertex forwardVertex, TVertex adjecentVertex);



        #endregion
    }
}
