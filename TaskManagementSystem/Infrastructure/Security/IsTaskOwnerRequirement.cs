// using System.Security.Claims;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Http;
// using Persistence;



// namespace Infrastructure.Security
// {
//     public class IsTaskOwnerRequirement : IAuthorizationRequirement
//     {

//     }


//     public class IsTaskOwnerRequirementHandler : AuthorizationHandler<IsTaskOwnerRequirement>
//     {
//         private readonly TaskManagementSystemDbContext _dbContext;
//         private readonly IHttpContextAccessor _httpContextAccessor;

//         public IsTaskOwnerRequirementHandler(TaskManagementSystemDbContext dbContext,
//         IHttpContextAccessor httpContextAccessor)
//         {
//             _dbContext = dbContext;
//             _httpContextAccessor = httpContextAccessor;
//         }


//         protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
//         IsTaskOwnerRequirement requirement)
//         {
//             var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
//             if (userId == null) return Task.CompletedTask;


//             var taskId = int.Parse(_httpContextAccessor.HttpContext?.Request.RouteValues
//                 .SingleOrDefault(x => x.Key == "id").Value?.ToString());
            
//             if (taskId == null) return Task.CompletedTask;


//         } 
//     }
// }