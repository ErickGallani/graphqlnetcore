namespace GraphQLTester.Types
{
    using GraphQL.Types;
    using GraphQLTester.Models.Models;

    public class StudentType : ObjectGraphType<Student>
    {
        public StudentType()
        {
            Field(x => x.Id).Description("The Id of the Student.");
            Field(x => x.Name, nullable: true).Description("The name of the Student.");
            Field(x => x.Age, nullable: true).Description("The age of the Student.");
            Field(x => x.SchoolRegisterNumber, nullable: true).Description("The school register number of the Student.");
        }
    }
}
