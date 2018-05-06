namespace GraphQLTester.Data
{
    using GraphQLTester.Models.Models;
    using Microsoft.EntityFrameworkCore;

    public class GraphQLTesterContext : DbContext
    {
        public GraphQLTesterContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Student> Students { get; set; }
    }
}
