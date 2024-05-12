using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
/***Generics
 * https://www.youtube.com/@WilliamFiset-videos
 * https://www.tutorialspoint.com/convert-directed-graph-into-a-tree
//https://www.w3computing.com/articles/csharp-generics-advanced-techniques-best-practices/#google_vignette
//https://www.fairushyn.tech/posts/csharp-learning-path/middle-specialist/generics
//https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/generics/constraints-on-type-parameters
//https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/where-generic-type-constraint
Generics End
**/

namespace AiComponents.Graph
{
    public class Graph<TVertex, TEdge> : BaseGraph<TVertex, TEdge>
       // where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TEdge : BaseGraphEdge< TVertex>, new()
    {
        public Graph(bool isDirectedGraph = false) : base(isDirectedGraph)
        {
        }

        public Graph(List<TVertex> vertexNodes, bool isDirectedGraph = false) : base(vertexNodes, isDirectedGraph)
        {
        }

        public Graph(List<KeyValuePair<TVertex, LinkedList<TEdge>>> allVertexNodesWithEdges, bool isDirectedGraph = false) : base(allVertexNodesWithEdges, isDirectedGraph)
        {
        }
    }
}
