using FuncBooksStore.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((hostContext, services) =>
    {
        // Add SQL Server connection
        _ = services.AddDbContext<BooksDbContext>(options =>
            options.UseSqlServer(hostContext.Configuration.GetConnectionString("SQLConnectionString")));

        services.AddLogging();

    })
    .Build();

host.Run();
