namespace StateFlowFramework
{
    public class NewFlowService : IFlowService
    {
        IFlowWorker flowWorker;

        public NewFlowService(IFlowWorker flowWorker)
        {
            this.flowWorker = flowWorker;
        }

        public string ChangeState(object user, string path, string condition)
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


        public string GetCurrentState(object user)
        {
            var flow = flowWorker.GetFlowStateById(StateValueHelper.GetCurrentStateValue(user));
            StateValueHelper.UpdateCurrentStateValue(user, flow.Id);
            StateValueHelper.UpdatePreivousStateValue(user, flow.Id);
            return flow.State;
        }

        public string GoToNextState(object user, string condition)
        {
            if (condition == null)
            {
                var currentState = flowWorker.GetFlowStateById(StateValueHelper.GetCurrentStateValue(user));
                currentState.Transitions.TryGetValue("default", out string nextStateName);
                var nextState = flowWorker.GetFlowStateByName(nextStateName);
                StateValueHelper.UpdateCurrentStateValue(user, nextState.Id);
                StateValueHelper.UpdatePreivousStateValue(user, currentState.Id);
                return nextState.State;
            }
            else
            {
                var currentState = flowWorker.GetFlowStateById(StateValueHelper.GetCurrentStateValue(user));
                currentState.Transitions.TryGetValue(condition, out string nextStateName);
                var nextState = flowWorker.GetFlowStateByName(nextStateName);
                StateValueHelper.UpdateCurrentStateValue(user, nextState.Id);
                StateValueHelper.UpdatePreivousStateValue(user, currentState.Id);
                return nextState.State;
            }
        }

        public string GoToPreviousState(object user)
        {
            var prevState = flowWorker.GetFlowStateById(StateValueHelper.GetPreviousStateValue(user));
            StateValueHelper.UpdatePreivousStateValue(user, StateValueHelper.GetCurrentStateValue(user));
            StateValueHelper.UpdateCurrentStateValue(user, prevState.Id);
            return prevState.State;
        }
    }
}
