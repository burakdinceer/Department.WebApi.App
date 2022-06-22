namespace Department.WebApi.App.Data.Dto
{
    public class PersonRequestDto
    {
        public string PersonName { get; set; }
        public string PersonSurname { get; set; }
        public int Age { get; set; }
        public string Education { get; set; }
        public int WorkId { get; set; }
    }
}
