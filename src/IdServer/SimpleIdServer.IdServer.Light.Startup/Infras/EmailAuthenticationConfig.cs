﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleIdServer.IdServer.Light.Startup.Infras;

public static class EmailAuthenticationConfig
{
    public static void Run(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Configuration.AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{webApplicationBuilder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        webApplicationBuilder.AddSidIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryUsers(Config.Users)
            .AddInMemoryLanguages(Config.Languages)
            .AddEmailAuthentication(true);

        var app = webApplicationBuilder.Build();
        app.Services.SeedData();
        app.UseSid();
        app.Run();
    }

    public static void RunWithRealm(WebApplicationBuilder webApplicationBuilder)
    {
        webApplicationBuilder.Configuration.AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{webApplicationBuilder.Environment.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
        webApplicationBuilder.AddSidIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryUsers(Config.Users)
            .AddInMemoryLanguages(Config.Languages)
            .AddInMemoryRealms(Config.Realms)
            .AddEmailAuthentication(true)
            .EnableRealm();

        var app = webApplicationBuilder.Build();
        app.Services.SeedData();
        app.UseSid();
        app.Run();
    }
}
