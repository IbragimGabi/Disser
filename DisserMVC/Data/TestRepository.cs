using DisserMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace DisserMVC.Data
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

        public Test GetTestsByUserId(string userId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.User.Id == userId);
        }

        public Test GetTestsByTestId(int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.TestId == testId);
        }

        public TestTask GetTestsByFlowId(string flowId, int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.TestId == testId).TestTasks.FirstOrDefault(_ => _.FlowStateName == flowId);
        }
    }
}

