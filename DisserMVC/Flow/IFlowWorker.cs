﻿namespace DisserMVC.Flow
{
    public interface IFlowWorker
    {
        FlowData GetFlow(int id);
        FlowState GetFlowStateById(int id);
        FlowState GetFlowStateByName(string name);
        int GetCondtition(int id, string condition);
    }
}
