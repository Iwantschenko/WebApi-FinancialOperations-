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
    public class OperationsType 
    {
        [Key]
        [Column("Operation_ID")]
        public Guid ID { get; set; }
        [Column("Operation_Name")]
        public string Name { get; set; }
        [Column("Operation_Description")]
        public string Description {get; set; }
        public ICollection<Transactions>? transactions { get; set; }
    }
}
