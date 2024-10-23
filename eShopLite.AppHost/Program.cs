using Projects;

var builder = DistributedApplication.CreateBuilder(args);

// Provisions an Azure SQL Database when published
//var sqlServer = builder.AddSqlServer("sqlserver")
//                       .PublishAsAzureSqlDatabase()
//                       .AddDatabase("ProductContext");

var sql = builder.AddSqlServer("sql")
                 .AddDatabase("ProductsContext");


//var cache = builder.AddRedis("cache")
//                   .PublishAsConnectionString();
var cache = builder.AddRedis("redis");

var products = builder.AddProject<Products>("products")
                .WithExternalHttpEndpoints()
                .WithReference(sql)
                .WithReference(cache);

builder.AddProject<Store>("store")
       .WithExternalHttpEndpoints()
       .WithReference(cache)
       .WithReference(sql)
       .WithReference(products);

builder.Build().Run();