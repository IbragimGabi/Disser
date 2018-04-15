using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisserMVC.Flow
{
    public interface IFlowWorker
    {
        FlowData GetFlow(int id);
    }
}
