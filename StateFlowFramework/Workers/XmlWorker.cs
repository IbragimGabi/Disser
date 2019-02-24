using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StateFlowFramework
{
    public class XmlWorker : IFlowWorker
    {
        XmlSerializer formatter = new XmlSerializer(typeof(FlowData[]));
        FlowData[] flows = null;

        public XmlWorker()
        {
            using (FileStream fs = new FileStream(@".\Configs\FlowConfig.xml", FileMode.Open))
            {
                flows = (FlowData[])formatter.Deserialize(fs);
            }
        }

        public int GetCondtition(int id, string condition)
        {
            throw new NotImplementedException();
        }

        public FlowData GetFlow(int id)
        {
            if (flows == null)
                using (FileStream fs = new FileStream(@".\Configs\FlowConfig.xml", FileMode.Open))
                {
                    flows = (FlowData[])formatter.Deserialize(fs);
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

        public void InitFlowWorker(string fileId)
        {
            throw new NotImplementedException();
        }
    }
}
