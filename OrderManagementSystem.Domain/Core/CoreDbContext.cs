using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.Domain.Core
{
    public interface ICoreDbContext
    {
        SqlConnection DbConnection { get; }
    }
}
