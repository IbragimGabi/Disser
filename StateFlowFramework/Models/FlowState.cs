using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StateFlowFramework
{
    [Serializable]
    [DataContract]
    public class FlowState
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public Dictionary<string, string> Transitions { get; set; }
    }
}
