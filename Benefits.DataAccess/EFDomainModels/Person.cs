using System;
using System.Collections.Generic;
using System.Text;

namespace Benefits.DataAccess.EFModels
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Relationship { get; set; }
        public int RelatedEmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
