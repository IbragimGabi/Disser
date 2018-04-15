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

        public string GetCurrentState(ApplicationUser user)
        {
            var flow = flowWorker.GetFlow(user.CurrentState);
            return flow.CurrentState;
        }

        public string GoToNextState(ApplicationUser user)
        {
            var flow = flowWorker.GetFlow(user.CurrentState);
            return flow.NextState;
        }

        public string GoToPreviousState(ApplicationUser user)
        {
            var flow = flowWorker.GetFlow(user.CurrentState);
            return flow.PreviousState;
        }
    }
}
