var builder = DistributedApplication.CreateBuilder(args);

var mailpit = builder.AddMailPit("mailpit");

var postgresDb = builder.AddPostgres("postgres")
    .WithPgWeb()
    //.WithPgAdmin()
    .WithDataVolume("sevdocs-postgres")
    .AddDatabase("postgresdb", "SevDocs");

var sqlite = builder.AddSqlite("sqlite", null, "jobs.db")
    .WithSqliteWeb();

builder.AddProject<Projects.SevDocs>("sevdocs")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WaitFor(postgresDb)
    .WithReference(postgresDb)
    .WithReference(sqlite)
    .WithReference(mailpit);

builder.Build().Run();
