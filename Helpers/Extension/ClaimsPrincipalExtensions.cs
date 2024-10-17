using System.Security.Claims;

namespace RunningGroupWebApp.Helpers.Extensions;

public static class ClaimsPrincipalExtensions
{
	public static string GetUserId(this ClaimsPrincipal claims)
	{
		return claims.FindFirst(ClaimTypes.NameIdentifier).Value;
	}
}