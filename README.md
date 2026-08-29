[![](https://img.shields.io/nuget/v/soenneker.blazor.auth.rolesprincipalfactory.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.auth.rolesprincipalfactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.auth.rolesprincipalfactory/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.auth.rolesprincipalfactory/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.auth.rolesprincipalfactory.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.auth.rolesprincipalfactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.auth.rolesprincipalfactory/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.auth.rolesprincipalfactory/actions/workflows/codeql.yml)

# Soenneker.Blazor.Auth.RolesPrincipalFactory

A Blazor WebAssembly account principal factory that maps a comma-separated `jobTitle` claim to standard .NET role claims.

## Installation

```bash
dotnet add package Soenneker.Blazor.Auth.RolesPrincipalFactory
```

## Registration

Register the factory on the authentication builder returned by `AddMsalAuthentication`:

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Soenneker.Blazor.Auth.RolesPrincipalFactory;

builder.Services
    .AddMsalAuthentication(options =>
    {
        builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    })
    .AddAccountClaimsPrincipalFactory<RolesPrincipalFactory>();
```

Do not also register another account claims principal factory; the last factory registration controls principal creation.

## Mapping behavior

Given this claim:

```text
jobTitle = Administrator, Billing.Read
```

the factory adds `ClaimTypes.Role` claims for `Administrator` and `Billing.Read`. Empty comma-delimited segments are ignored, surrounding whitespace is trimmed, and casing is preserved.

The resulting principal works with normal Blazor role checks:

```razor
<AuthorizeView Roles="Administrator">
    <Authorized>
        <AdminDashboard />
    </Authorized>
</AuthorizeView>
```

```csharp
bool isAdministrator = user.IsInRole("Administrator");
```

Only use this mapping when the identity provider treats `jobTitle` as an authorization-controlled value. A normal profile job title is usually descriptive data, and promoting it to a role can grant unintended access. For Microsoft Entra app roles emitted through the `roles` claim, use `Soenneker.Blazor.Auth.EntraRolesPrincipalFactory` instead.
