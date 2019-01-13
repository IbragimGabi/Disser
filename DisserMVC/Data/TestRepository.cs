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

        public List<Tests> GetAllTests()
        {
            return _dbContext.Tests.ToList();
        }

        public Tests GetTestsByUserId(string userId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.User.Id == userId);
        }

        public Tests GetTestsByTestId(int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.Id == testId);
        }

        public TestTasks GetTestsByFlowId(string flowId, int testId)
        {
            return _dbContext.Tests.FirstOrDefault(_ => _.Id == testId).TestTasks.FirstOrDefault(_ => _.FlowStateName == flowId);
        }
    }
}

