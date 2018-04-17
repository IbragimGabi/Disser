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
        FlowData[] flows = null;

        public JsonWorker()
        {
            using (FileStream fs = new FileStream("FlowConfig.json", FileMode.Open))
            {
                flows = (FlowData[])jsonFormatter.ReadObject(fs);
            }
        }

        public FlowData GetFlow(int id)
        {
            if (flows == null)
                using (FileStream fs = new FileStream("FlowConfig.json", FileMode.Open))
                {
                    flows = (FlowData[])jsonFormatter.ReadObject(fs);
                }
            return flows.FirstOrDefault(_ => _.Id == id);
        }
    }
}
