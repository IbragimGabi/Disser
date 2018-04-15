﻿using DisserMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisserMVC.Services
{
    public interface IFlowService
    {
        string GoToNextState(ApplicationUser user);
        string GoToPreviousState(ApplicationUser user);
        string GetCurrentState(ApplicationUser user);
    }
}