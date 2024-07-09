using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class TransactionsEntity
    {
        public Guid Transaction_Id { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid OperationTypeID {  get; set; }
        public OperationTypeEntity? OperationType { get; set; }
    }
}
