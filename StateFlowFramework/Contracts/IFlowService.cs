namespace StateFlowFramework
{
    public interface IFlowService
    {
        string GoToNextState(object user, string condition);
        string GoToPreviousState(object user);
        string GetCurrentState(object user);
        string ChangeState(object user, string path, string condition);
        void InitFlowService(string fileId);
    }
}
