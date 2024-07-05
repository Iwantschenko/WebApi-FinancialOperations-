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
        public Guid ID { get; set; }
        public string Name { get; set; }    
        public string Type { get; set; }    

        public ICollection<Transactions>? transactions { get; set; }
    }
}
