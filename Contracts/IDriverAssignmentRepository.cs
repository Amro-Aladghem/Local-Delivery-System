using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDriverAssignmentRepository
    {
        void CreateDriverAssignment(DriverAssignment driverAssignment);
        void DeleteDriverAssignment(DriverAssignment driverAssignment);
        Task<DriverAssignment> GetDriverAssignment(int Id, bool trackChanges);
        void UpdateDriverAssignment(DriverAssignment driverAssignment);
    }
}
