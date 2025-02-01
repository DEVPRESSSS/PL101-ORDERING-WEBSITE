using Microsoft.EntityFrameworkCore;

namespace ONLINE_BUSINESS_PROJECT_FOR_PL101_SUBJECT.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
