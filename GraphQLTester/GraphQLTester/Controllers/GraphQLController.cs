namespace GraphQLTester.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using GraphQL;
    using GraphQL.Types;
    using GraphQLTester.Models.Models;
    using GraphQLTester.Queries;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class GraphQLController : Controller
    {
        private StudentQuery studentQuery { get; set; }

        public GraphQLController(StudentQuery studentQuery)
        {
            this.studentQuery = studentQuery;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var schema = new Schema { Query = this.studentQuery };

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = query.Query;

            }).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result.Errors.First().Message);
            }

            return Ok(result);
        }
    }
}