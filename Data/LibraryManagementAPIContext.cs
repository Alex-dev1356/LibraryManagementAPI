using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Data
{
    public class LibraryManagementAPIContext : DbContext
    {
        public LibraryManagementAPIContext(DbContextOptions<LibraryManagementAPIContext> options) 
            :base(options)
        {
            
        }
    }
}
