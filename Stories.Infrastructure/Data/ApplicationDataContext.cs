using Microsoft.EntityFrameworkCore;

namespace Stories.Infrastructure.Data;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
    //Precisa configurar o banco com o OnModelCreating
}
