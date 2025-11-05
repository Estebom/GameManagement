using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GameManagement.Data;

namespace GameManagement.Data
{
    public class GameManagementContext(DbContextOptions<GameManagementContext> options) : IdentityDbContext<GameManagementUser>(options)
    {
    }
}
