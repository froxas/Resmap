namespace Resmap.Domain
{
    public class Employee : BaseEntity
    {        
        public string EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public JobTitle JobTitle { get; set; }        

        public Department Department { get; set; }        
        public bool IsSubcontractor { get; set; }
         
        public Address Address { get; set; }
        public Contact Contact { get; set; }
                
        public Note Note { get; set; }       
    }
}
