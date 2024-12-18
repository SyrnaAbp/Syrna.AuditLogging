# Syrna.AuditLogging
Private Messaging module for ABP framework.

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FVoloAbpPackageVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FSyrnaAbp%2FSyrna.AuditLogging%2Fmaster%2FDirectory.Packages.props)](https://abp.io)
![build and test](https://img.shields.io/github/actions/workflow/status/SyrnaAbp/Syrna.AuditLogging/build-all.yml?branch=dev&style=flat-square)
[![NuGet Download](https://img.shields.io/nuget/dt/Syrna.AuditLogging.Application.svg?style=flat-square)](https://www.nuget.org/packages/Syrna.AuditLogging.Application)
[![NuGet (with prereleases)](https://img.shields.io/nuget/vpre/Syrna.AuditLogging.Application.svg?style=flat-square)](https://www.nuget.org/packages/Syrna.AuditLogging.Application) 

An abp application module that allows users to send private messages to each other.

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/SyrnaAbp/SyrnaAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * Syrna.AuditLogging.Application
    * Syrna.AuditLogging.Application.Contracts
    * Syrna.AuditLogging.Domain
    * Syrna.AuditLogging.Domain.Shared
    * Syrna.AuditLogging.EntityFrameworkCore
    * Syrna.AuditLogging.HttpApi
    * Syrna.AuditLogging.HttpApi.Client
    * Syrna.AuditLogging.Web
    * Syrna.AuditLogging.Blazor
    * Syrna.AuditLogging.Blazor.Server
    * Syrna.AuditLogging.Blazor.WebAssembly

1. Add `DependsOn(typeof(SyrnaAuditLoggingXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/SyrnaAbp/SyrnaAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureAuditLogging();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).

## Usage


## Reference

### This project based on [SuperAbp AuditLogging](https://github.com/SuperAbp/AuditLogging)

### Differences

1. Demo project created for OpenIddict
2. Demo project extended modules added
3. Blazor modules added
4. AuditList sorting applied
5. 

