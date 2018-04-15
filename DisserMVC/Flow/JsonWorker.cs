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
        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(FlowData[]));

        public FlowData GetFlow(int id)
        {
            FlowData[] flow;
            using (FileStream fs = new FileStream("FlowConfig.json", FileMode.Open))
            {
                flow = (FlowData[])jsonFormatter.ReadObject(fs);
            }
            return flow.FirstOrDefault(_ => _.Id == id);
        }
    }
}
