namespace GraphQLTester.Queries
{
    using GraphQL.Types;
    using GraphQLTester.Data.Specs;
    using GraphQLTester.Types;

    public class StudentQuery : ObjectGraphType
    {
        private IStudentRepository _studentRepository { get; set; }

        public StudentQuery(IStudentRepository _studentRepository)
        {
            Field<StudentType>(
              "student1",
              resolve: context => _studentRepository.Get(1)
            );
        }
    }
}
