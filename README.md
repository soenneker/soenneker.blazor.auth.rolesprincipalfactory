[![](https://img.shields.io/nuget/v/soenneker.blazor.auth.rolesprincipalfactory.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.auth.rolesprincipalfactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.auth.rolesprincipalfactory/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.auth.rolesprincipalfactory/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.blazor.auth.rolesprincipalfactory.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.blazor.auth.rolesprincipalfactory/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.blazor.auth.rolesprincipalfactory/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.blazor.auth.rolesprincipalfactory/actions/workflows/codeql.yml)

# Soenneker.Blazor.Auth.RolesPrincipalFactory

Customizes Blazor WebAssembly authentication by extending AccountClaimsPrincipalFactory to add user roles based on their job title.

## Install

```bash
dotnet add package Soenneker.Blazor.Auth.RolesPrincipalFactory
```

## What you get

- `IRolesPrincipalFactory` — Customizes Blazor WebAssembly authentication by extending AccountClaimsPrincipalFactory to add user roles based on their job title.
