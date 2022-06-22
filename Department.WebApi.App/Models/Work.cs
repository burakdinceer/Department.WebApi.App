using System.Collections.Generic;

namespace Department.WebApi.App.Models
{
    public class Work
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
