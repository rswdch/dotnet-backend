using Microsoft.EntityFrameworkCore;

namespace EF7Relationships.Data;

public class DataContext: DbContext
{
    public DataContext(DbContextOptions<DataContext> options): base(options)
    {
        
    }
}