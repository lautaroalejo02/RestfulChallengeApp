# RestfulChallengeApp
Desafio Nubimetrics para Backend
En este link puede probar los endpoints
[Restful Challenge](https://restfulappchallenge.azurewebsites.net/swagger/index.html)
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
Luego de este paso debe ejecutar el siguiente comando en la consola PM
```
update-database
```
En caso de que no funcione debera ejecutar lo siguiente
```
Add-Migration
```
Y luego nuevamente
```
update-database
```
