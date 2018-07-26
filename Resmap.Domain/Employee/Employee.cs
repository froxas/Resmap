using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Resmap.Domain
{
    public class Employee : BaseEntity
    {        
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("JobTitle")]
        public Guid? JobTitleId { get; set; }
        public JobTitle JobTitle { get; set; }

        [ForeignKey("Department")]
        public Guid? DepartmentId { get; set; }
        public Department Department { get; set; }

        public bool IsSubcontractor { get; set; }

        [ForeignKey("Relation")]
        public Guid? SubcontractorId { get; set; }
        public Relation Subcontractor { get; set; }

        public Address Address { get; set; }
        public Contact Contact { get; set; }
                
        public Note Note { get; set; }       
    }
}
