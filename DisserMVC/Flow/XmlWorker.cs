using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DisserMVC.Flow
{
    public class XmlWorker : IFlowWorker
    {
        XmlSerializer formatter = new XmlSerializer(typeof(FlowData[]));
        FlowData[] flows = null;

        public XmlWorker()
        {
            using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
            {
                flows = (FlowData[])formatter.Deserialize(fs);
            }
        }

        public FlowData GetFlow(int id)
        {
            if (flows == null)
                using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
                {
                    flows = (FlowData[])formatter.Deserialize(fs);
                }
            return flows.FirstOrDefault(_ => _.Id == id);
        }
    }
}
