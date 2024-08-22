using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dto
{
    public class OperationTypeDto
    {
        [Required]
        [MinLength(1 , ErrorMessage ="MinLength 1")]
        public string Name { get; set; }
        public bool IsIncome { get; set; }
    }
}
