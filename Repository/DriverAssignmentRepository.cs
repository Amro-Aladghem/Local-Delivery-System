using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Exceptions;
using Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DriverAssignmentRepository : RepositoryBase<DriverAssignment>, IDriverAssignmentRepository
    {
        public DriverAssignmentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDriverAssignment(DriverAssignment driverAssignment)
        {
            Create(driverAssignment);
        }
        public void DeleteDriverAssignment(DriverAssignment driverAssignment)
        {
            Delete(driverAssignment);
        }
        public async Task<DriverAssignment> GetDriverAssignment(int Id, bool trackChanges)
        {
            DriverAssignment? driverAssignment = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (driverAssignment == null)
                throw new EntityWithIntNotFound(Id, nameof(DriverAssignment));

            return driverAssignment!;
        }
        public void UpdateDriverAssignment(DriverAssignment driverAssignment)
        {
            Update(driverAssignment);
        }
    }
}
