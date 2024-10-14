using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// Provisions an Azure SQL Database when published
var sqlServer = builder.AddSqlServer("sqlserver")
                       .PublishAsAzureSqlDatabase()
                       .AddDatabase("ProductContext");

var cache = builder.AddRedis("cache")
                   .PublishAsConnectionString();

var products = builder.AddProject<Products>("products")
                .WithExternalHttpEndpoints()
                .WithReference(sqlServer)
                .WithReference(cache);

builder.AddProject<Store>("store")
       .WithExternalHttpEndpoints()
       .WithReference(products);

builder.Build().Run();