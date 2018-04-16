using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace DisserMVC.Flow
{
    [Serializable]
    [DataContract]
    public class FlowData
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string CurrentState { get; set; }
        [DataMember]
        public int PreviousState { get; set; }
        [DataMember]
        public int NextState { get; set; }
    }
}
