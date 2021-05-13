#### Scaffold Context and Entities From Database
```shell
dotnet ef dbcontext scaffold "Server=ST-DEVELOP-LENO;Database=OrderManagementSystem;User Id=sa;Password=12345;" Microsoft.EntityFrameworkCore.SqlServer -o Entities --context-dir Context -c NameContext
```.
