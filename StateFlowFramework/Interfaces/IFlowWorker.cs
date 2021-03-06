﻿using System.Collections.Generic;

namespace StateFlowFramework
{
    public interface IFlowWorker
    {
        FlowData GetFlow(int id);
        FlowState GetFlowStateById(int id);
        FlowState GetFlowStateByName(string name);
        int GetCondtition(int id, string condition);
        void InitFlowWorker(string fileId);
        void CreateConfig(List<FlowState> states, string fileId);
    }
}
