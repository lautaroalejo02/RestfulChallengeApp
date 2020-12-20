# RestfulChallengeApp
Desafio Nubimetrics para Backend
## DB Usage
La base de datos actual esta montada en un servidor Azure asi que se puede usar sin ningun problema.
En caso de querer usar una base de datos local. Sera necesario seguir los siguientes pasos
1- Ir al archivo Startup.cs y dejarlo de la siguiente manera
```c#
public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<UserDbContext>(option => option.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=UsersDb;"));
            services.AddSwaggerGen(options =>
            {
                options.EnableAnnotations();
               
            });

        }
```
