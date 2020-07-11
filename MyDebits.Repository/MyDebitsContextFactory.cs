using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MyDebits.Repository
{
    public class MyDebitsContextFactory : IDesignTimeDbContextFactory<MyDebitsContext>
    {
        public MyDebitsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDebitsContext>();
            optionsBuilder.UseSqlite("Data Source=MyDebitDB.db");

            return new MyDebitsContext(optionsBuilder.Options);
        }
    }
}
