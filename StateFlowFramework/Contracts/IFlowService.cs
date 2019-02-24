using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateFlowFramework
{
    public interface IFlowService
    {
        string GoToNextState(object user, string condition);
        string GoToPreviousState(object user);
        string GetCurrentState(object user);
        string ChangeState(object user, string path, string condition);
    }
}
