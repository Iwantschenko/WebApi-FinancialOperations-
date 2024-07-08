using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Transactions
    {
        public Guid Transaction_Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid OperationTypeID {  get; set; }
        public OperationType? OperationType { get; set; }
    }
}
