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

        public string ChangeState(ApplicationUser user, string path, string condition)
        {
            string state = "";
            if (path == "next")
                state = GoToNextState(user, condition);
            if (path == "previous")
                state = GoToPreviousState(user);
            if (path == null)
                state = GetCurrentState(user);
            return state;
        }

        public string GetCurrentState(ApplicationUser user)
        {
            FlowData flow;
            if (user.CurrentState == 0)
                flow = flowWorker.GetFlow(user.CurrentState + 1);
            else
                flow = flowWorker.GetFlow(user.CurrentState);
            user.CurrentState = flow.Id;
            user.PreviousState = -1;
            return flow.CurrentState;
        }

        public string GoToNextState(ApplicationUser user, string condition)
        {
            if (condition == null)
            {
                var flow = flowWorker.GetFlow(user.CurrentState);
                var nextState = flowWorker.GetFlow(flow.NextState);
                user.CurrentState = nextState.Id;
                user.PreviousState = -1;
                return nextState.CurrentState;
            }
            else
            {
                int stateId = flowWorker.GetCondtition(user.CurrentState, condition);
                var nextState = flowWorker.GetFlow(stateId);
                user.PreviousState = user.CurrentState;
                user.CurrentState = nextState.Id;
                return nextState.CurrentState;
            }
        }

        public string GoToPreviousState(ApplicationUser user)
        {
            if (user.PreviousState == -1)
            {
                var flow = flowWorker.GetFlow(user.CurrentState);
                var nextState = flowWorker.GetFlow(flow.PreviousState);
                user.CurrentState = nextState.Id;
                user.PreviousState = -1;
                return nextState.CurrentState;
            }
            else
            {
                var flow = flowWorker.GetFlow(user.PreviousState);
                var nextState = flowWorker.GetFlow(flow.Id);
                user.CurrentState = nextState.Id;
                user.PreviousState = -1;
                return nextState.CurrentState;
            }
        }
    }
}
