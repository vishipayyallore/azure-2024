using FuncBooksStore.Persistence;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;

namespace FuncBooksStore
{
    public class GetAllBooks(BooksDbContext dbContext)
    {
        //private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly BooksDbContext _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        //public GetAllBooks(ILoggerFactory loggerFactory)
        //{
        //    _logger = loggerFactory.CreateLogger<GetAllBooks>();
        //}

        [Function("GetAllBooks")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            //_logger.LogInformation("C# HTTP trigger function processed a request.");

            var books = await _dbContext.Books.ToListAsync();

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            var json = JsonSerializer.Serialize(books);
            response.WriteString(json);

            return response;
        }
    }
}
