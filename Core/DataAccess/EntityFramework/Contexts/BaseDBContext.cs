using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Core.DataAccess.EntityFramework.Contexts
{
    public class BaseDBContext : DbContext
    {
        protected IConfiguration _configuration;

        protected BaseDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
