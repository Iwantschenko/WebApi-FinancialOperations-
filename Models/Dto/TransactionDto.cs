using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public class TransactionDto
    {
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public Guid OperationTypeID { get; set; }
    }
}

