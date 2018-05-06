namespace GraphQLTester.Data.Specs
{
    using System.Threading.Tasks;
    using GraphQLTester.Models.Models;

    public interface IStudentRepository
    {
        Task<Student> Get(int id);
    }
}
