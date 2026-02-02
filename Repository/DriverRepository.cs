using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;
using Contracts;
using Entities.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class DriverRepository :RepositoryBase<Driver>, IDriverRepository    
    {
        public DriverRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        { }
        public void CreateDriver(Driver driver)
        {
            Create(driver);
        }
        public void DeleteDriver(Driver driver)
        {
            Delete(driver);
        }
        public async Task<Driver> GetDriver(Guid Id, bool trackChanges)
        {
            Driver? driver = await FindByCondition(D => D.Id == Id, trackChanges).SingleOrDefaultAsync();

            if (driver == null)
                throw new EntityWithGuidNotFound(Id, nameof(Driver));

            return driver!;
        }
        public void UpdateDriver(Driver driver)
        {
            Update(driver);
        }
    }
}
