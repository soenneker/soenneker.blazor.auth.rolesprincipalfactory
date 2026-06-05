using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using Soenneker.Blazor.Auth.RolesPrincipalFactory.Abstract;
using Soenneker.Extensions.IIdentity;
using Soenneker.Extensions.ValueTask;

namespace Soenneker.Blazor.Auth.RolesPrincipalFactory;

/// <inheritdoc cref="IRolesPrincipalFactory"/>
public sealed class RolesPrincipalFactory: AccountClaimsPrincipalFactory<RemoteUserAccount>, IRolesPrincipalFactory
{
    public RolesPrincipalFactory(IAccessTokenProviderAccessor accessor) : base(accessor)
    {
    }

    /// <summary>
    /// Creates user async.
    /// </summary>
    /// <param name="account">The account.</param>
    /// <param name="options">The options.</param>
    /// <returns>A task containing the result of the operation.</returns>
    public override async ValueTask<ClaimsPrincipal> CreateUserAsync(RemoteUserAccount account, RemoteAuthenticationUserOptions options)
    {
        ClaimsPrincipal user = await base.CreateUserAsync(account, options);

        user.Identity.AddRolesFromJobTitle();

        return user;
    }
}
