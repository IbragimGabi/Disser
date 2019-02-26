using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace StateFlowFramework
{
    public class ScxmlWorker : IFlowWorker
    {
        private string configFileId;
        private List<FlowState> states = null;

        public ScxmlWorker()
        {
        }

        public void InitFlowWorker(string fileId)
        {
            configFileId = fileId;
            states = LoadConfig();
        }

        public void CreateConfig(List<FlowState> states, string fileId)
        {
            XmlDocument xml = new XmlDocument();
            //xml.Load($@".\Configs\BaseConfig.scxml");
            XDocument doc = new XDocument();
            XElement element;
            XElement lastElement = null;
            var scxml = new XElement("scxml");
            foreach (var state in states)
            {
                if (state.State == "Initial")
                {
                    element = new XElement("initial");
                    foreach (var trans in state.Transitions)
                    {
                        if (trans.Key != "default")
                        {
                            element.Add(new XElement("transition",
                                                    new XAttribute("event", trans.Key),
                                                    new XAttribute("target", trans.Value)
                                                    ));
                        }
                        else
                        {
                            element.Add(new XElement("transition", new XAttribute("target", trans.Value)));
                        }
                    }
                    scxml.AddFirst(element);
                    continue;
                }
                if (state.State == "Final")
                {
                    lastElement = new XElement("final", new XAttribute("id", state.State));
                    continue;
                }
                element = new XElement("state", new XAttribute("id", state.State));
                foreach (var trans in state.Transitions)
                {
                    if (trans.Key != "default")
                    {
                        element.Add(new XElement("transition",
                                                new XAttribute("event", trans.Key),
                                                new XAttribute("target", trans.Value)
                                                ));
                    }
                    else
                    {
                        element.Add(new XElement("transition", new XAttribute("target", trans.Value)));
                    }
                }
                scxml.Add(element);
            }
            scxml.Add(lastElement);
            doc.Add(scxml);

            var path = $@".\Configs\{fileId}.scxml";

            doc.Save(path);
            File.WriteAllLines(path, File.ReadAllLines(path).Skip(1));
        }

        public List<FlowState> LoadConfig()
        {
            List<FlowState> states = new List<FlowState>();
            XmlDocument xml = new XmlDocument();
            xml.Load($@".\Configs\{configFileId}.scxml");
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
