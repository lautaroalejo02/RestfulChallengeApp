# RestfulChallengeApp
Desafio Nubimetrics para Backend
En este link puede probar los endpoints
[Restful Challenge](https://restfulappchallenge.azurewebsites.net/swagger/index.html)
## Creacion del proyecto
Para usar este proyecto lo ideal es clonar este proyecto en un proyecto de Visual Studio 2019 con los workloads de ASP.NET and web development y el de Data storage
Para clonar ese proyecto debe seleccionar clonar un repositorio y llenar los siguientes campos
Link del repositorio a clonar https://github.com/lautaroalejo02/RestfulChallengeApp.git

![Image of clonerepo](https://nimbus-screenshots.s3.amazonaws.com/s/fca8f78e28f7f7c117f63fc64936fcfa.png)

Al clonar ese proyecto puede demorar un poco al tener que usar los paquetes requeridos del proyecto

## DB Usage
### La base de datos actual esta montada en un servidor Azure asi que al clonar el repositorio puede usarla sin necesidad de tener la bd local.
### En caso de querer usar una base de datos local. Sera necesario seguir los siguientes pasos
#### Ir al archivo Startup.cs y dejarlo de la siguiente manera
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
### Luego de este paso debe ejecutar el siguiente comando en la consola PM

```
Add-Migration
```
### Y luego nuevamente
```
update-database
```
#### Despues de realizar estos pasos deberia ver una base de datos llamada UserDb con una tabla Users en su servidor local
#### Esta base de datos debe ser populada con el siguiente script
```SQL
SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (1, N'Lautaro', N'Alejo', N'lautitomasalejo@gmail.com', N'Testing')
INSERT INTO [dbo].[Users] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (2, N'Tomas', N'Alejo', N'lautarotomasalejo@gmai.com', N'12345')
INSERT INTO [dbo].[Users] ([Id], [Nombre], [Apellido], [Email], [Password]) VALUES (3, N'Lisandro', N'Alejo', N'mario@gmail.com', N'$2a$11$a6nfBSHLDPfHoIGgmJE7U.FgJjTJev1MwyDTLq4Zg7oev3mYISOgu')
SET IDENTITY_INSERT [dbo].[Users] OFF

```
Luego de este paso, ya podria utilizar la base de datos para el desafio 3 sin nigun problema


##Para utilizar los endpoints debe usar las siguientes direcciones 
### DESAFIO 1
https://restfulappchallenge.azurewebsites.net/api/RestfulApp/paises/AR
https://restfulappchallenge.azurewebsites.net/api/RestfulApp/paises/CO
https://restfulappchallenge.azurewebsites.net/api/RestfulApp/paises/BR
#### En caso de usar bd local
https://localhost:portnumber/api/RestfulApp/paises/AR
https://localhost:portnumber/api/RestfulApp/paises/CO
https://localhost:portnumber/api/RestfulApp/paises/BR

### DESAFIO 2
https://restfulappchallenge.azurewebsites.net/api/RestfulApp/busqueda/iphone11
#### En caso de usar bd local
https://localhost:portnumber/api/RestfulApp/busqueda/iphone11

### DESAFIO 3
##### Ver todos los usuarios
https://restfulappchallenge.azurewebsites.net/Usuarios/User/
##### Ver 1 usuario
https://restfulappchallenge.azurewebsites.net/Usuarios/User/2
#### En caso de usar bd local
##### Ver todos los usuarios
https://localhost:portnumber/Usuarios/User/
##### Ver 1 usuario
https://localhost:portnumber/Usuarios/User/2
