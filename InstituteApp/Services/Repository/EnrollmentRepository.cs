using InstituteApp.DAL;
using InstituteApp.Models;
using InstituteApp.Services.IRepository;

namespace InstituteApp.Services.Repository
{
    public class EnrollmentRepository : Repository<Enrollment>, IEnrollmentRepository
    {
        public EnrollmentRepository(InstituteContext context) : base(context)
        {
        }
    }
}
