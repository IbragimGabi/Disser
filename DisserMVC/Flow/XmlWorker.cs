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

        public FlowData GetFlow(int id)
        {
            FlowData[] flow;
            using (FileStream fs = new FileStream("persons.xml", FileMode.Open))
            {
                flow = (FlowData[])formatter.Deserialize(fs);
            }
            return flow.FirstOrDefault(_ => _.Id == id);
        }
    }
}
