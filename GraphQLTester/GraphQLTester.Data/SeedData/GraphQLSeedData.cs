namespace GraphQLTester.Data.SeedData
{
    using System.Linq;
    using GraphQLTester.Models.Models;

    public static class GraphQLSeedData
    {
        public static void SeedData(this GraphQLTesterContext db)
        {
            if (!db.Students.Any())
            {
                var student = new Student
                {
                    Name = "Richards",
                    Age = 22,
                    SchoolRegisterNumber = "SRU837361"
                };

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}
