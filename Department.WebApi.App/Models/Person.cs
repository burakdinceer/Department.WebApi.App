using System.ComponentModel.DataAnnotations.Schema;

namespace Department.WebApi.App.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }

        [ForeignKey("WorkId")]
        public virtual Work Work { get; set; }
        
        public  int WorkId { get; set; }
    }
}
