var builder = DistributedApplication.CreateBuilder(args);

var mailpit = builder.AddMailPit("mailpit");

var postgresDb = builder.AddPostgres("postgres")
    .WithPgWeb()
    //.WithPgAdmin()
    .WithDataVolume()
    .AddDatabase("postgresdb", "SevDocs");

builder.AddProject<Projects.SevDocs>("sevdocs")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WaitFor(postgresDb)
    .WithReference(postgresDb)
    .WithReference(mailpit);

builder.Build().Run();
