using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class OperationTypeEntity
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }    
        public bool IsIncome { get; set; }    

        public ICollection<TransactionsEntity>? transactions { get; set; }
    }
}
