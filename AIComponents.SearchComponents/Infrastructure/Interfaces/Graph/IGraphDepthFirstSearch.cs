using AiComponents.Graph.BaseComponents;
using AiComponents.Graph.Interfaces;
using AIComponents.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AIComponents.SearchComponents.Infrastructure.Interfaces.Graph
{
    public partial interface IGraphDepthFirstSearch< TVertex>
            //where TNodeContext : NodeBaseContextEntity
        where TVertex : BaseGraphNode//<TNodeContext>
    {
        Stack<TVertex> ForwardFrontierStack { get; }
        Stack<TVertex> ReverseFrontierStack { get; }
    }
}
