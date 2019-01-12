using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace DisserMVC.Flow
{
    public class JsonWorker : IFlowWorker
    {
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(FlowData[]), new DataContractJsonSerializerSettings()
        {
            UseSimpleDictionaryFormat = true
        });
        FlowData[] flows = null;

        public JsonWorker()
        {
            using (FileStream fs = new FileStream(@".\Configs\FlowConfig.json", FileMode.Open))
            {
                flows = (FlowData[])jsonFormatter.ReadObject(fs);
            }
        }

        public int GetCondtition(int id, string condition)
        {
            if (flows == null)
                using (FileStream fs = new FileStream(@".\Configs\FlowConfig.json", FileMode.Open))
                {
                    flows = (FlowData[])jsonFormatter.ReadObject(fs);
                }
            var flow = flows.FirstOrDefault(_ => _.Id == id);
            var nextStateId = flow.Conditions.FirstOrDefault(_ => _.Key == condition).Value;
            return nextStateId;
        }

        public FlowData GetFlow(int id)
        {
            if (flows == null)
                using (FileStream fs = new FileStream(@".\Configs\FlowConfig.json", FileMode.Open))
                {
                    flows = (FlowData[])jsonFormatter.ReadObject(fs);
                }
            return flows.FirstOrDefault(_ => _.Id == id);
        }

        public FlowState GetFlowStateById(int id)
        {
            throw new NotImplementedException();
        }

        public FlowState GetFlowStateByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
