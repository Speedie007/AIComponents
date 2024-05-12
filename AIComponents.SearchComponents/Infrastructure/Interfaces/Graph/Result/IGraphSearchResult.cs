using AiComponents.Graph.BaseComponents;
using AIComponents.Data.Domain;
using AIComponents.SearchComponents.SearchGraph.Result.ResultSets;

namespace AIComponents.SearchComponents.Infrastructure.Interfaces.Graph.Result
{
    public partial interface IGraphSearchResult< TVertex, TResultSet>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
          where TResultSet : BaseGraphResultSet<TVertex>, new()
    {
        TResultSet GenerateNewResultSet();
    }
}
