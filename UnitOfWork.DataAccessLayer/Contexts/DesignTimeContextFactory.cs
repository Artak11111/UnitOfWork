using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace UnitOfWork.DataAccessLayer.Contexts
{
    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private const string TargetDbConnectionString = "Server=localhost;Port=3306;Database=UnitOfWorkDb;Uid=root;Pwd=password;";

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseMySQL(TargetDbConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
