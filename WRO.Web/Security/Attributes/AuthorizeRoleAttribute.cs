using Microsoft.AspNetCore.Authorization;
using WRO.Web.Security.Constants;

namespace WRO.Web.Security.Attributes;

/// <summary>
/// Bu attribute controller və ya action səviyyəsində role autorizasiyası üçün nəzərdə tutulub.
/// </summary>
public class AuthorizeRoleAttribute : AuthorizeAttribute
{
    public AuthorizeRoleAttribute(params UserRole[] roles)
    {
        // UserRole.Admin -> "Admin"
        // UserRole.Admin, UserRole.User -> "Admin,User"

        Roles = string.Join(',', roles);
    }
}
