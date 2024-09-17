using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Interfaces.Repository
{
    public interface IMotoRepository : IBaseRepository<Moto>
    {
    }
}
