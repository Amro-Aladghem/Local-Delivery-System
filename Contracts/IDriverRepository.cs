using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Contracts
{
    public interface IDriverRepository
    {
        void CreateDriver(Driver driver);
        void DeleteDriver(Driver driver);
        Task<Driver> GetDriver(Guid Id, bool trackChanges);
        void UpdateDriver(Driver driver);
    }
}
