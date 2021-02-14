using Benefits.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Benefits.Services.Interfaces
{
    public interface IBenefitsService
    {
        public void CalculateCosts(IEmployee[] employees);
    }
}
