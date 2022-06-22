namespace Department.WebApi.App.Data.Dto
{
    public class PersonResponseDto
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public string PersonFullName { get; set; }
       
        public int Age { get; set; }
        public string Education { get; set; }
        public int WorkId { get; set; }
        public string WorkName { get; set; }
    }
}
