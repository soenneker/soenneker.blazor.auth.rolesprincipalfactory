namespace Soenneker.Blazor.Auth.RolesPrincipalFactory.Abstract;

/// <summary>
/// Marks the account principal factory that splits the <c>jobTitle</c> claim on commas and adds each nonblank value as a standard <see cref="System.Security.Claims.ClaimTypes.Role"/> claim.
/// </summary>
public interface IRolesPrincipalFactory
{
}
