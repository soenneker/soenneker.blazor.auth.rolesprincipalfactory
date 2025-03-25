using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Soenneker.Blazor.Auth.RolesPrincipalFactory.Abstract;
using Soenneker.Extensions.IIdentity;

namespace Soenneker.Blazor.Auth.RolesPrincipalFactory;

/// <inheritdoc cref="IRolesPrincipalFactory"/>
public class RolesPrincipalFactory: AccountClaimsPrincipalFactory<RemoteUserAccount>, IRolesPrincipalFactory
{
    public RolesPrincipalFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }

    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
    {
        ClaimsPrincipal user = await base.CreateUserAsync(account, options);

        user.Identity.AddRolesFromJobTitle();

        return user;
    }
}