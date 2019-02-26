using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateFlowFramework;
using System.Collections.Generic;
using System.Linq;

namespace StateFlowFrameworkUnitTests
{
    [TestClass]
    public class ScxmlWorkerUnitTest
    {
        [TestMethod]
        public void TestCreateConfig()
        {
            var flowWorker = new ScxmlWorker();
            var states = new List<FlowState>();

            var state = new FlowState
            {
                Id = 0,
                State = "Initial",
                Transitions = new Dictionary<string, string>
            {
                { "default", "FirstState" }
            }
            };
            states.Add(state);

            state = new FlowState
            {
                Id = 1,
                State = "FirstState",
                Transitions = new Dictionary<string, string>
            {
                { "SS", "SecondState" },
                { "FS", "FinalState" }
            }
            };
            states.Add(state);

            state = new FlowState
            {
                Id = 2,
                State = "SecondState",
                Transitions = new Dictionary<string, string>
            {
                { "FS2", "FinalState" }
            }
            };
            states.Add(state);

            state = new FlowState
            {
                Id = 3,
                State = "Final",
                Transitions = new Dictionary<string, string>()
            };
            states.Add(state);
            flowWorker.CreateConfig(states, "TestFile");

            flowWorker.InitFlowWorker("TestFile");
            var states2 = flowWorker.LoadConfig();

            for (int i = 0; i < states.Count; i++)
            {
                Assert.AreEqual(states[i].Id, states2[i].Id);
                Assert.AreEqual(states[i].State, states2[i].State);
                Assert.AreEqual(ToAssertableString(states[i].Transitions), ToAssertableString(states2[i].Transitions));
            }
        }

        public string ToAssertableString(IDictionary<string, string> dictionary)
        {
            var pairStrings = dictionary.OrderBy(p => p.Key)
                                        .Select(p => p.Key + ": " + string.Join(", ", p.Value));
            return string.Join("; ", pairStrings);
        }
    }
}
