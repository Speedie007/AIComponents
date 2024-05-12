using AIComponents.Data.Domain;
using AiComponents.Graph.BaseComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.SearchComponents.SearchGraph.Result.ResultSets
{
    public partial class GraphStandardResultSet< TVertex> :
        BaseGraphResultSet< TVertex>
        //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        public GraphStandardResultSet() : base()
        {

        }
    }
}
