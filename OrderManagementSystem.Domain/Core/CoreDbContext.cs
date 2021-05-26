using Microsoft.Data.SqlClient;

namespace OrderManagementSystem.Domain.Core
{
    public interface ICoreDbContext
    {
        SqlConnection DbConnection { get; }
    }
}
