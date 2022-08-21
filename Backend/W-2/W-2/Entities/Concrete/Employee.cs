using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Employee : IEntity
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public decimal? Salary { get; set; }

    }
}
