using DisserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisserMVC.Services
{
    public interface IFlowService
    {
        string GoToNextState(ref ApplicationUser user, string condition);
        string GoToPreviousState(ref ApplicationUser user);
        string GetCurrentState(ref ApplicationUser user);
        string ChangeState(ref ApplicationUser user, string path, string condition);
    }
}
