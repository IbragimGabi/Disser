using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace StateFlowFramework
{
    public class ScxmlWorker : IFlowWorker
    {
        private List<FlowState> states = null;

        public ScxmlWorker()
        {
            states = LoadConfig();
        }

        private List<FlowState> LoadConfig()
        {
            List<FlowState> states = new List<FlowState>();
            XmlDocument xml = new XmlDocument();
            xml.Load(@".\Configs\FlowConfig.scxml");
            XmlElement xRoot = xml.DocumentElement;
            int i = 0;
            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Name == "initial")
                {
                    var init = new FlowState
                    {
                        Id = 0,
                        State = "Initial"
                    };
                    var initTransitions = xnode.ChildNodes;
                    if (initTransitions != null)
                    {
                        init.Transitions = new Dictionary<string, string>();
                        foreach (XmlNode transition in initTransitions)
                        {
                            if (transition.Attributes.GetNamedItem("event") != null)
                            {
                                init.Transitions.Add(transition.Attributes.GetNamedItem("event").Value, transition.Attributes.GetNamedItem("target").Value);
                            }
                            else
                            {
                                init.Transitions.Add("default", transition.Attributes.GetNamedItem("target").Value);
                                break;
                            }
                        }
                    }
                    states.Add(init);
                    i++;
                    continue;
                }

                var state = new FlowState
                {
                    Id = i,
                    State = xnode.Attributes.GetNamedItem("id").Value
                };
                i++;
                var transitions = xnode.ChildNodes;
                if (transitions != null)
                {
                    state.Transitions = new Dictionary<string, string>();
                    foreach (XmlNode transition in transitions)
                    {
                        if (transition.Attributes.GetNamedItem("event") != null)
                        {
                            state.Transitions.Add(transition.Attributes.GetNamedItem("event").Value, transition.Attributes.GetNamedItem("target").Value);
                        }
                        else
                        {
                            state.Transitions.Add("default", transition.Attributes.GetNamedItem("target").Value);
                            break;
                        }
                    }
                }
                states.Add(state);
            }
            return states;
        }

        public int GetCondtition(int id, string condition)
        {
            throw new NotImplementedException();
        }

        public FlowData GetFlow(int id)
        {
            throw new NotImplementedException();
        }

        public FlowState GetFlowStateById(int id)
        {
            if (states == null)
            {
                states = LoadConfig();
            }

            return states.FirstOrDefault(_ => _.Id == id);
        }

        public FlowState GetFlowStateByName(string name)
        {
            if (states == null)
            {
                states = LoadConfig();
            }

            return states.FirstOrDefault(_ => _.State == name);
        }
    }
}
