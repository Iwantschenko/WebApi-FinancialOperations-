using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Configuration
{
    public static class InitialData
    {
        public static Guid IncomeOperationTypeId = Guid.NewGuid();
        public static Guid ExpensesOperationTypeId = Guid.NewGuid();
    }
}
