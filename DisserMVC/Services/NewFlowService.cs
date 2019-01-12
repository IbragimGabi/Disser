using DisserMVC.Flow;
using DisserMVC.Models;

namespace DisserMVC.Services
{
    public class NewFlowService : IFlowService
    {
        IFlowWorker flowWorker;

        public NewFlowService(IFlowWorker flowWorker)
        {
            this.flowWorker = flowWorker;
        }

        public string ChangeState(ApplicationUser user, string path, string condition)
        {
            string state = "";
            if (path == "next")
            {
                state = GoToNextState(user, condition);
            }

            if (path == "previous")
            {
                state = GoToPreviousState(user);
            }

            if (path == null)
            {
                state = GetCurrentState(user);
            }

            return state;
        }

        public string GetCurrentState(ApplicationUser user)
        {
            var flow = flowWorker.GetFlowStateById(user.CurrentState);
            user.CurrentState = flow.Id;
            user.PreviousState = flow.Id;
            return flow.State;
        }

        public string GoToNextState(ApplicationUser user, string condition)
        {
            if (condition == null)
            {
                var currentState = flowWorker.GetFlowStateById(user.CurrentState);
                currentState.Transitions.TryGetValue("default", out string nextStateName);
                var nextState = flowWorker.GetFlowStateByName(nextStateName);
                user.CurrentState = nextState.Id;
                user.PreviousState = currentState.Id;
                return nextState.State;
            }
            else
            {
                var currentState = flowWorker.GetFlowStateById(user.CurrentState);
                currentState.Transitions.TryGetValue(condition, out string nextStateName);
                var nextState = flowWorker.GetFlowStateByName(nextStateName);
                user.CurrentState = nextState.Id;
                user.PreviousState = currentState.Id;
                return nextState.State;
            }
        }

        public string GoToPreviousState(ApplicationUser user)
        {
            var prevState = flowWorker.GetFlowStateById(user.PreviousState);
            user.PreviousState = user.CurrentState;
            user.CurrentState = prevState.Id;
            return prevState.State;
        }
    }
}
