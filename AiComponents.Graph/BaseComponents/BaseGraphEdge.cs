

using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;


namespace AiComponents.Graph.BaseComponents
{
    //TEntity,TEdgeNode
    //where TNodeContext : NodeBaseContextEntity
    public abstract partial class BaseGraphEdge< TVertex>//, TNodeContext> 
        : IGraphEdge<TVertex>//,TNodeContext>
       // where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        #region cstor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vertexNode">Parent Vertex(NodeDataContext)</param>
        /// <param name="adjacentNode">Child Vertex(NodeDataContext)</param>
        public BaseGraphEdge(TVertex vertexNode, TVertex adjacentNode)
        {
            Edge = new KeyValuePair<TVertex, TVertex>(key: vertexNode, value: adjacentNode);
        }

        protected BaseGraphEdge()
        {
            Edge = new KeyValuePair<TVertex, TVertex>();
        }

        #endregion
        public KeyValuePair<TVertex, TVertex> Edge { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Integer value which is the Id value of the child(To) Vertex(NodeDataContext)</returns>
        public virtual TVertex GetAdjacentVertex()
        {
            return Edge.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        ///  <returns>Integer value which is the Id value of the parent(From) Vertex(NodeDataContext)</returns>
        public virtual TVertex GetVertex()
        {
            return Edge.Key;
        }
    }
}
