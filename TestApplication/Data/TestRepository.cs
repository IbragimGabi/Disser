using System.Collections.Generic;
using System.Linq;
using TestApplication.Models;

namespace TestApplication.Data
{
    public class TestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public TestRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Test> GetAllTests()
        {
            return _dbContext.Tests.ToList();
        }

        public List<Test> GetTestsByUserId(string userId)
        {
            return _dbContext.Tests.Where(_ => _.User.Id == userId).ToList();
        }

        public Test GetTestByTestId(int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.TestId == testId);
        }

        public TestTask GetTestsByFlowId(string flowId, int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.TestId == testId).TestTasks.FirstOrDefault(_ => _.FlowStateName == flowId);
        }
    }
}

