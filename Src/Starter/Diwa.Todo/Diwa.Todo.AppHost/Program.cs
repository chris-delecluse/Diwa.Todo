var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.Diwa_Todo_Api_Adapter>("diwa-todo-api");

builder.AddProject<Projects.Diwa_Todo_BlazorUI_Adapter>("diwa-todo-blazor-ui")
    .WithReference(apiService);

builder.Build().Run();