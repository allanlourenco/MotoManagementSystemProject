using MotoManagementSystemProject.Data.Context;
using MotoManagementSystemProject.Data.Repository;
using MotoManagementSystemProject.Domain.Entities;
using MotoManagementSystemProject.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Data.Implementation
{
    public class LocacaoRepository : BaseRepository<Locacao>, ILocacaoRepository
    {
        public LocacaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
