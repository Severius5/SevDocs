var builder = DistributedApplication.CreateBuilder(args);

var postgresDb = builder.AddPostgres("postgres")
    .WithPgWeb()
    //.WithPgAdmin()
    .WithDataVolume()
    .AddDatabase("postgresdb", "SevDocs");

builder.AddProject<Projects.SevDocs>("sevdocs")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WaitFor(postgresDb)
    .WithReference(postgresDb);

builder.Build().Run();
