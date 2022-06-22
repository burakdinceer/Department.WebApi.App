using Department.WebApi.App.Data;
using Department.WebApi.App.Interfaces;
using Department.WebApi.App.Models;

namespace Department.WebApi.App.Repositories
{
    public class WorkRepository : GenericRepository<Work>, IGenericRepository<Work>
    {
        public WorkRepository(DataContext context) : base(context)
        {
        }
    }
}
