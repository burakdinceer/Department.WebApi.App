using Department.WebApi.App.Data;
using Department.WebApi.App.Interfaces;
using Department.WebApi.App.Models;

namespace Department.WebApi.App.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IGenericRepository<Person>
    {
        public PersonRepository(DataContext context) : base(context)
        {
        }

        


    }
}
