using AiComponents.Graph.BaseComponents;
using AIComponents.Common.Result;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.Infrastructure.Interfaces.Graph.Result;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.SearchComponents.SearchGraph.Result
{
    public partial class GraphSearchResult<TVertex, TResultSet> :
        BaseResult, IGraphSearchResult<TVertex, TResultSet>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
        where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        public List<TResultSet> ResultSets { get; private set; }
        public GraphSearchResult()
        {
            ResultSets = new List<TResultSet>();
        }

        public virtual TResultSet GenerateNewResultSet()
        {
            return new TResultSet();
        }

        public void ClearResultSets()
        {
            ResultSets.Clear();
        }

        public override void LogResults()
        {
            base.LogResults();
            if (Success)
            {
                Console.WriteLine($"NO - Errors Found For:[{nameof(GraphSearchResult<TVertex, TResultSet>)}]-[{nameof(ResultSets)}]");
                var count = 1;
                foreach (var item in ResultSets)
                {
                    Console.WriteLine($"Forward Set - {count}");
                    foreach (var result in item.PreOrder_ForwardTracking)
                        Console.Write($"FN:{result.NodeDataContext.Id},");
                    Console.WriteLine();
                    Console.WriteLine("---------");
                    Console.WriteLine($"Reverse Set - {count}");
                    foreach (var result in item.PostOrder_BackTracking)
                        Console.Write($"RN:{result.NodeDataContext.Id},");
                    Console.WriteLine();    
                    Console.WriteLine("---------");
                    count++;
                }
            }
            else
            {
                Console.WriteLine($"");
                foreach (var error in Errors)
                    foreach (var errorMessage in error.AllErrorMessages)
                    {
                        Console.WriteLine($"Error Logged:Type-[{nameof(GraphSearchResult< TVertex, TResultSet>)}]-[{error.GetType().Name}]\nMessage:{errorMessage}");
                    }
                Console.WriteLine("---------");
            }

        }
    }
}
