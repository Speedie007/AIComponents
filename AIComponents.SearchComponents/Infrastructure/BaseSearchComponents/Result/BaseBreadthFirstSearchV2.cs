using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Events.Node;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Enumeration;
using AIComponents.SearchComponents.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.SearchComponents.Infrastructure.BaseSearchComponents
{
    public abstract partial class BaseBreadthFirstSearchV2<T, TGraph, TFrontier> : BaseSearch<T, TGraph, TFrontier>
        where TGraph : IGraph<T, INode<T>, IEdge<T>>
        where TFrontier : Queue<INode<T>>, ICollection<INode<T>>, new()
        where T : BaseEntity
    {
        protected BaseBreadthFirstSearchV2(TGraph graph, INode<T> startVertexNode, EnumSearchType searchType) : base(graph, startVertexNode, searchType)
        {
           
        }


        public override void ExcuteSearch()
        {
            //Ensure That the Graph and Search Queue is correctly initialized by Restting to defaults before starting the BFS.
            ResetSearch();

            // Mark the current node(Starting Node) as visited and enqueue it
            var vertexNode = Graph.GetVertex(StartVertexNode.GetNodeIdentifier());
            vertexNode.MarkNodeAsVisited();
            Frontier.Enqueue(vertexNode);

            while (Frontier.Count > 0)
            {
                // Dequeue a vertex from queue and Process it
                var currentNode = Frontier.Dequeue();

                // Get all adjacent vertices of the dequeued
                // vertex currentNode If an adjacent has not
                // been visited, then mark it visited and
                // enqueue it
                foreach (var edge in Graph.GetEdges((BaseNode<T>)currentNode))
                {
                    var adjacentVertexNode = Graph.GetVertex(edge.GetAdjacentVertex().GetNodeIdentifier());
                    if (!adjacentVertexNode.IsVisited)
                    {
                        adjacentVertexNode.MarkNodeAsVisited();
                        Frontier.Enqueue(adjacentVertexNode);
                    }
                }
            }
        }

        public override void ProcessFirstVisitedVertexNode(FirstNodeVisitedEventArgs<T> args)
        {
            Console.WriteLine($"First Node Items To Be Processed - {args.NodeItem.Id}");
        }

        public override void ProcessLastVisitedVertexNode(LastNodeVisitedEventArgs<T> args)
        {
            Console.WriteLine($"First Node Items To Be Processed - {args.NodeItem.Id}");
        }

        public override void ProcessVertexNodeLevelChanged(NodeLevelEventArgs<T> args)
        {
            Console.WriteLine($"Node Item - {args.NodeItem.Id} Level Changed To {args.NewLeveL} Pervious Level {args.PreviousLevel}");
        }

        public override void ProcessVisitedVertexNode(NodeVisitedEventArgs<T> args)
        {
            Console.WriteLine($"Next Node Items To Be Processed - {args.NodeItem.Id}");
        }
    }
}
