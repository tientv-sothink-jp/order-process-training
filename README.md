#### Scaffold Context and Entities From Database
```shell
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Server=ST-DEVELOP-LENO;Database=OrderManagementSystem;User Id=sa;Password=12345;" Microsoft.EntityFrameworkCore.SqlServer -o <Folder Entity> --context-dir <Directory Context> -c <Name Context>
```.
