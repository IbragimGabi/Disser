namespace StateFlowFramework
{
    public static class StateValueHelper
    {
        public static int GetCurrentStateValue(object user)
        {
            var field = user.GetType().GetField("CurrentState");
            return (int)field.GetValue(user);
        }

        public static int GetPreviousStateValue(object user)
        {
            var field = user.GetType().GetField("PreviousState");
            return (int)field.GetValue(user);
        }

        public static void UpdateCurrentStateValue(object user, int stateId)
        {
            var field = user.GetType().GetField("CurrentState");
            field.SetValue(user, stateId);
        }

        public static void UpdatePreivousStateValue(object user, int stateId)
        {
            var field = user.GetType().GetField("PreviousState");
            field.SetValue(user, stateId);
        }
    }
}
