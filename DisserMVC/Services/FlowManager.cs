using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace DisserMVC.Flow
{
    public static class FlowManager
    {
        private static string CurrentState = null;
        private static string PreviousState = null;
        private static string NextState = null;
        private static bool isFirst = true;

        public static void Startup()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(".\\FlowConfig.xml");
            XmlElement xRoot = xml.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                PreviousState = null;
                CurrentState = xnode.Attributes.GetNamedItem("Id").Value;
                NextState = xnode.Attributes.GetNamedItem("Next").Value;
                break;
            }
        }

        public static string GoToNextState()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(".\\FlowConfig.xml");
            XmlElement xRoot = xml.DocumentElement;
            string view = null;
            if (isFirst)
            {
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.GetNamedItem("Id").Value == CurrentState)
                    {
                        PreviousState = CurrentState;
                        CurrentState = NextState;
                        NextState = xnode.Attributes.GetNamedItem("Next").Value;
                        view = xnode.Attributes.GetNamedItem("View").Value;
                        break;
                    }
                }
                isFirst = false;
            }
            else
            {
                foreach (XmlNode xnode in xRoot)
                {
                    if (xnode.Attributes.GetNamedItem("Id").Value == NextState)
                    {
                        PreviousState = CurrentState;
                        CurrentState = NextState;
                        NextState = xnode.Attributes.GetNamedItem("Next").Value;
                        view = xnode.Attributes.GetNamedItem("View").Value;
                        break;
                    }
                }
            }
            return view;
        }
    }
}
