namespace GraphQLTester.Data.Repositories
{
    using System.Threading.Tasks;
    using GraphQLTester.Data.Specs;
    using GraphQLTester.Models.Models;
    using Microsoft.EntityFrameworkCore;

    public class StudentRepository : IStudentRepository
    {
        private GraphQLTesterContext db { get; set; }

        public StudentRepository(GraphQLTesterContext db)
        {
            this.db = db;
        }

        public Task<Student> Get(int id)
        {
            return this.db.Students.FirstOrDefaultAsync(student => student.Id == id);
        }
    }
}
