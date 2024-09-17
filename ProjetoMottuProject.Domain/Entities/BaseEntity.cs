using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoManagementSystemProject.Domain.Entities
{
    public class BaseEntityAudit : BaseEntityWithKey
    {
        public DateTime CriadoEm { get; set; }
        public DateTime? AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
    }

    public class BaseEntityWithKey : BaseEntity
    {
        public string Id { get; set; }
    }

    public class BaseEntity
    {

    }
}
