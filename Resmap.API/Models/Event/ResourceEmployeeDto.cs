namespace Resmap.API.Models
{
    public class ResourceEmployeeDto : ResourceDto
    {
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public bool IsSubcontractor { get; set; }   
    }
}
