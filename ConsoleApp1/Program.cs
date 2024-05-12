using AiComponents.Graph;
using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.SearchGraph;
using AIComponents.SearchComponents.SearchGraph.BreadthFirstSearch;
using AIComponents.SearchComponents.SearchGraph.DepthFirstSearch;
using AIComponents.SearchComponents.SearchGraph.Result;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;
using Microsoft.Build.Graph;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ListOfStudentNodes = new List<GraphNode>()
            {
                new GraphNode(new Student(){
                    Id = 0,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true),
                 new GraphNode(new Student(){
                    Id = 1,
                 FirstName = "Claire",
                  LastName = "Wood"

                }),
                new GraphNode(new Student()
                {
                     Id = 2,
                     FirstName = "Kevin",
                     LastName = "Wood"
                }),


                new GraphNode(new Student()
                {
                     Id = 3,
                     FirstName = "Cheryl",
                     LastName = "Wood"
                }),
                new GraphNode(new Student()
                {
                     Id = 4,
                     FirstName = "Casey",
                     LastName = "Wood"
                }),

                new GraphNode(new Student(){
                    Id = 5,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true),
                new GraphNode(new Student(){
                    Id = 6,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true),
                new GraphNode(new Student(){
                    Id = 7,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true),
                new GraphNode(new Student(){
                    Id = 8,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true)
                ,
                new GraphNode(new Student(){
                    Id = 9,
                     FirstName= "Brendan",
                     LastName = "Wood"
                },true)
            };

            var undirectedGraph = new Graph<
                GraphNode,
                GraphEdge<GraphNode>
                >(ListOfStudentNodes);

            Dictionary<int, List<int>> UndirectedEdgeMap = new Dictionary<int, List<int>>()
            {
                { 0, new List<int>(){ 1,2} },
                { 1, new List<int>(){ 0,2,3,4 } },
                { 2, new List<int>(){ 0,1} },
                { 3, new List<int>(){ 1,5} },
                { 4, new List<int>(){ 1 } },
                { 5, new List<int>(){ 3,6,7,8} },
                { 6, new List<int>(){ 5} },
                { 7, new List<int>(){ 5,8} },
                { 8, new List<int>(){ 5,7,9} },
                { 9, new List<int>(){ 8} }
            };
            foreach (var item in UndirectedEdgeMap)
            {
                var vertex = ListOfStudentNodes.Where(x => x.NodeDataContext.Id == item.Key).FirstOrDefault();

                foreach (var AdjacentVetrexID in item.Value)
                {
                    var Adjcent = ListOfStudentNodes.Where(x => x.NodeDataContext.Id == AdjacentVetrexID).FirstOrDefault();
                    undirectedGraph.TryAddEdge(new GraphEdge<GraphNode>(vertex, Adjcent));
                }
            }


            var startingNode = ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 0).FirstOrDefault();

            //Console.WriteLine("/***********Undirected Graph - BFS*******************/");
            //var searchBFS = new BreadthFirstSearch<
            //    Graph<GraphNode, GraphEdge<GraphNode>>,
            //    GraphNode,
            //    GraphEdge<GraphNode>,
            //    GraphStandardResultSet<GraphNode>
            //    >(undirectedGraph, startingNode);
            //searchBFS.ExcuteSearch();
            //searchBFS.SearchResult.LogResults();

            //Console.WriteLine("/***********Undirected Graph - Iteritive DFS*******************/");
            //var searchIteritiveDFS = new DepthFirstSearchIterativeTraversal<

            //    Graph<GraphNode, GraphEdge<GraphNode>>,
            //    GraphNode,
            //    GraphEdge<GraphNode>,
            //    GraphStandardResultSet<GraphNode>
            //    >(undirectedGraph, startingNode);
            //searchIteritiveDFS.ExcuteSearch();
            //searchIteritiveDFS.SearchResult.LogResults();

            //Console.WriteLine("/***********Undirected Graph - Recursive DFS*******************/");
            //var searchRecersiveDFS = new DepthFirstSearchRecursiveTraversal<
            //    Graph<GraphNode, GraphEdge<GraphNode>>,
            //    GraphNode,
            //    GraphEdge<GraphNode>,
            //    GraphStandardResultSet<GraphNode>
            //    >(undirectedGraph, startingNode);
            //searchRecersiveDFS.ExcuteSearch();
            //searchRecersiveDFS.SearchResult.LogResults();

            //Console.WriteLine("/***********Directed Graph - Recursive DFS*******************/");
            var directedGraph = new Graph<
               GraphNode,
               GraphEdge<GraphNode>
               >(ListOfStudentNodes, true);
            Dictionary<int, List<int>> directedEdgeMap = new Dictionary<int, List<int>>()
            {
                { 0, new List<int>(){ 1,2} },
                { 1, new List<int>(){ 2,3,4 } },
                { 2, new List<int>(){ } },
                { 3, new List<int>(){ 5} },
                { 4, new List<int>(){ } },
                { 5, new List<int>(){ 6,7,8} },
                { 6, new List<int>(){ } },
                { 7, new List<int>(){ 8} },
                { 8, new List<int>(){ 9} },
                { 9, new List<int>(){ } }
            };
            foreach (var item in directedEdgeMap)
            {
                var vertex = ListOfStudentNodes.Where(x => x.NodeDataContext.Id == item.Key).FirstOrDefault();

                foreach (var AdjacentVetrexID in item.Value)
                {
                    var Adjcent = ListOfStudentNodes.Where(x => x.NodeDataContext.Id == AdjacentVetrexID).FirstOrDefault();
                    directedGraph.TryAddEdge(new GraphEdge<GraphNode>(vertex, Adjcent));
                }
            }
            var TopologicalSortDFS = new DepthFirstSearchRecursiveTraversal<
                Graph<GraphNode, GraphEdge<GraphNode>>,
                GraphNode,
                GraphEdge<GraphNode>,
                GraphStandardResultSet<GraphNode>
                >(directedGraph, startingNode);
            TopologicalSortDFS.ExcuteSearch();
            TopologicalSortDFS.SearchResult.LogResults();
        }
    }

    ////Set up the Edges for each Node
    //foreach (var node in ListOfStudentNodes)
    //{
    //    if (node.GetNodeIdentifier() == 1)
    //    {
    //        var forward = new GraphWeightedEdge<GraphNode, int>(node, ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 3).FirstOrDefault(), node.NodeDataContext.Id);
    //        var reverse = new GraphWeightedEdge<GraphNode, int>(ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 3).FirstOrDefault(), node, node.NodeDataContext.Id);
    //        undirectedGraph.TryAddEdge(forward, reverse);

    //        forward = new GraphWeightedEdge<GraphNode, int>(node, ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 2).FirstOrDefault(), node.NodeDataContext.Id);
    //        reverse = new GraphWeightedEdge<GraphNode, int>(ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 2).FirstOrDefault(), node, node.NodeDataContext.Id);
    //        undirectedGraph.TryAddEdge(forward, reverse);
    //    }

    //    if (node.GetNodeIdentifier() == 3)
    //    {
    //        var forward = new GraphWeightedEdge<GraphNode, int>(node, ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 5).FirstOrDefault(), node.NodeDataContext.Id);
    //        var reverse = new GraphWeightedEdge<GraphNode, int>(ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 5).FirstOrDefault(), node, node.NodeDataContext.Id);
    //        undirectedGraph.TryAddEdge(forward, reverse);

    //        forward = new GraphWeightedEdge<GraphNode, int>(node, ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 4).FirstOrDefault(), node.NodeDataContext.Id);
    //        reverse = new GraphWeightedEdge<GraphNode, int>(ListOfStudentNodes.Where(x => x.NodeDataContext.Id == 4).FirstOrDefault(), node, node.NodeDataContext.Id);
    //        undirectedGraph.TryAddEdge(forward, reverse);
    //    }

    //}
}
