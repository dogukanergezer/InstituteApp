using InstituteApp.Models;
using InstituteApp.Services.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstituteApp.Services
{
    public interface IInstructorRepository : IRepository<Instructor>
    {
        Task<IEnumerable<Instructor>> InstructorsAsync();
        Task<Instructor> InstructorAsync(int id);
    }
}
