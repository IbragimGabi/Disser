using DisserMVC.Flow;
using DisserMVC.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DisserMVC.Services
{
    public class FlowService : IFlowService
    {
        IFlowWorker flowWorker;

        public FlowService(IFlowWorker flowWorker)
        {
            this.flowWorker = flowWorker;
        }

        public string GetCurrentState(ref ApplicationUser user)
        {
            FlowData flow;
            if (user.CurrentState == 0)
                flow = flowWorker.GetFlow(user.CurrentState + 1);
            else
                flow = flowWorker.GetFlow(user.CurrentState);
            user.CurrentState = flow.Id;
            return flow.CurrentState;
        }

        public string GoToNextState(ref ApplicationUser user)
        {
            var flow = flowWorker.GetFlow(user.CurrentState);
            var nextState = flowWorker.GetFlow(flow.NextState);
            user.CurrentState = nextState.Id;
            return nextState.CurrentState;
        }

        public string GoToPreviousState(ref ApplicationUser user)
        {
            var flow = flowWorker.GetFlow(user.CurrentState);
            var nextState = flowWorker.GetFlow(flow.PreviousState);
            user.CurrentState = nextState.Id;
            return nextState.CurrentState;
        }
    }
}
