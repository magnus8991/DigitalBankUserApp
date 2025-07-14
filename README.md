# DigitalBankUserApp

//Descripción y ejecución del proyecto UserApp.API

El proyecto Backend o de API de la solución se ejecuta en local como acostumbra a ejecutarse un proyecto realizado en C# con el framework .NET (en este caso la versión 8), y el proyecto a ejecutar tiene por nombre UserApp.API, que se encuentra alojado en la subcarpeta "UserApp.API".
En dicha solución Backend se contemplan diversos patrones y arquitecturas como: Arquitectura por capas y MVC.

Adicional a lo anterior, es necesario resaltar que para poder crear la  base de datos en local se requiere la ejecución de las migraciones previamente creadas. De manera personal, el método que utilizo para realizarlo es el siguiente:

1. En VisualStudio nos vamos al menú Ver --> Otras Ventanas --> Consola del administrador de paquetes.
2. Abierta la consola, nos ubicamos o seleccionamos como proyecto predeterminado el proyecto de Persistencia, y procedemos a ejecutar el siguiente comando: $env:DefaultConnection="Server=localhost;Uid=root;Pwd=11014221dM.;Database=UserAppDb;" (este comando se encarga de configurar la variable de entorno de la cadena de conexión para poder ejecutar las migraciones con éxito).
3. Luego ejecutamos el comando que ejecuta las migraciones: dotnet ef database update --verbose --project .\UserApp.Data\ --startup-project .\UserApp.API\
4. Por último, verificamos que en nuestro entorno local todo se haya creado correctamente.



//Descripción y ejecución del proyecto UserApp.Web

El proyecto Frontend (Web) de la solución se ejecuta en local como acostumbra a ejecutarse un proyecto realizado en C# con el framework .NET (en este caso la versión 8), y el proyecto a ejecutar tiene por nombre UserApp.API, que se encuentra alojado en la subcarpeta "UserApp.Web".
En dicha solución Frontend se contempla el patrón MVC.
