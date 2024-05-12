
using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;

namespace AiComponents.Graph.Interfaces
{
    public partial interface IGraphEdge<TVertex>//, TNodeContext>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {

        TVertex GetVertex();
        /// <summary>
        /// Allso Known as Adjacent NodeDataContext
        /// </summary>
        /// <returns>Parent/Adjacent NodeDataContext</returns>
        TVertex GetAdjacentVertex();
        //aseGraphEdge<TVertex,TVertex> forwardEdge, BaseGraphEdge<TVertex, TVertex> reverseEdge
        KeyValuePair<TVertex, TVertex> Edge { get; set; }

         
        

    }
}
